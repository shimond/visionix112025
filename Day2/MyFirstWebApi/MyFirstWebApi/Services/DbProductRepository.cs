using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApi.Services
{
    public class DbProductRepository (VxDataContext db)  : IProductRepository
    {
        public async Task AddProductAsync(ProductEntity product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await db.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            var products = await db.Products
                .AsNoTracking()
                .Include(x=>x.Category)
                .ToListAsync();
            
            return products;
        }

        public async Task<ProductEntity?> GetProductByIdAsync(Guid id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
