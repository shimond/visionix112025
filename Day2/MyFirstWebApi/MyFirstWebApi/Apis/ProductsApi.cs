using Microsoft.AspNetCore.Http.HttpResults;
using MyFirstWebApi.Models.Dtos;

namespace MyFirstWebApi.Apis;

public static class ProductsApi
{
    public static IEndpointRouteBuilder MapProductApis(this IEndpointRouteBuilder app, IConfiguration configuration)
    {
        var productsGroup = app.MapGroup("/api/products")
            //.RequireAuthorization();
            .WithTags("Products");

        productsGroup.MapDelete("{id}",DeleteProduct);
        productsGroup.MapGet("", GetAllProductsAsync).AllowAnonymous();
        productsGroup.MapPost("", CreateProductAsync);
        productsGroup.MapGet("{id}", GetProductByIdAsync);
        productsGroup.MapPut("{id}", UpdateProduct);
        return app;
    }

    static async Task<NoContent> UpdateProduct(IProductRepository repository, Guid id, ProductDto product)
    {
        var mapped = new ProductEntity(product.Id, product.Name, product.Price, product.Description);
        await repository.UpdateProductAsync(mapped);
        return TypedResults.NoContent();
    }
    static async Task<NoContent> DeleteProduct(IProductRepository repository, Guid id)
    {
        await repository.DeleteProductAsync(id);
        return TypedResults.NoContent();
    }
    static async Task<Results<Ok<ProductEntity>, NotFound>> GetProductByIdAsync(IProductRepository repository, Guid id)
    {
        var product = await repository.GetProductByIdAsync(id);
        if (product is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(new ProductEntity(product.Id, product.Name, product.Price, product.Description));
    }
    static async Task<Ok<List<ProductEntity>>> GetAllProductsAsync(IProductRepository repository)
    {
        var products = await repository.GetAllProductsAsync();
        return TypedResults.Ok(products.Select(x => new ProductEntity(x.Id, x.Name, x.Price, x.Description))
            .ToList());
    }
    static async Task<Created<ProductDto>> CreateProductAsync(IProductRepository repository, ProductDto product)
    {
        var mapped = new ProductEntity(product.Id, product.Name, product.Price, product.Description);
        await repository.AddProductAsync(mapped);
        return TypedResults.Created($"/api/products/{product.Id}", product);
    }
}
