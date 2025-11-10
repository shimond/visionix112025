namespace MyFirstWebApi.Contracts;

public interface IProductRepository
{
    Task<List<ProductEntity>> GetAllProductsAsync();
    Task<ProductEntity?> GetProductByIdAsync(Guid id);
    Task AddProductAsync(ProductEntity product);
    Task UpdateProductAsync(ProductEntity product);
    Task DeleteProductAsync(Guid id);
}
