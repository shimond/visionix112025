using Microsoft.AspNetCore.OutputCaching;
using MyFirstWebApi.Contracts;
using MyFirstWebApi.Models.Dtos;

namespace MyFirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductRepository _productRepository) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return Ok(products.Select(x => new ProductEntity(x.Id, x.Name, x.Price, x.Description))
            .ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if(product == null)
        {
            return NotFound();
        }
        var res = new ProductDto(product.Id, product.Name, product.Price, product.Description);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductDto product)
    {
        var mapped = new ProductEntity(product.Id, product.Name, product.Price, product.Description);
        await _productRepository.AddProductAsync(mapped);
        return Created($"/api/products/{product.Id}", product);
    }
}


