using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Add
        public async Task CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }
        //Get
        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            return await _dbContext.Products
                .Where(p => p.Name.Contains(productName))
                .ToListAsync();
        }
        //Delete
        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true; // Producto eliminado exitosamente
        }
        //Update

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
