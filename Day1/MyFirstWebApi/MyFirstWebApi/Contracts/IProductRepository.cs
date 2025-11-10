

namespace MyFirstWebApi.Contracts;

public interface IProductRepository
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductDto product);
    Task UpdateProductAsync(ProductDto product);
    Task DeleteProductAsync(int id);
}
