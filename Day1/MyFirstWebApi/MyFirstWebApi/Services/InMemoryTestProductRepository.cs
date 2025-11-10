using MyFirstWebApi.Contracts;

namespace MyFirstWebApi.Services
{
    public class InMemoryTestProductRepository : IProductRepository
    {

        public InMemoryTestProductRepository()
        {
                
        }

        public List<ProductEntity> _store = new List<ProductEntity>();

        public Task AddProductAsync(ProductEntity product)
        {
            var existing = _store.FirstOrDefault(p => p.Id == product.Id);
            if (existing is not null)
            {
                throw new InvalidOperationException("Product with the same ID already exists.");
            }
            _store.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProductAsync(Guid id)
        {
            var isExisting = _store.RemoveAll(p => p.Id == id);
            if (isExisting == 0)
            {
                throw new InvalidOperationException("Product not found.");
            }
            return Task.CompletedTask;
        }

        public Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return Task.FromResult(_store);
        }

        public async Task<ProductEntity?> GetProductByIdAsync(Guid id)
        {
            await Task.Delay(500); // Simulate some latency
            var product = _store.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Task UpdateProductAsync(ProductEntity product)
        {
            var existingIndex = _store.FindIndex(p => p.Id == product.Id);
            if (existingIndex == -1)
            {
                throw new InvalidOperationException("Product not found.");
            }
            _store[existingIndex] = product;
            return Task.CompletedTask;
        }
    }
}
