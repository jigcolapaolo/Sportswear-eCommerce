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
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            return await _dbContext.Products
                .Where(p => p.Name.Contains(productName))
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            return product;
        }

        //Delete
        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true; //Producto eliminado exitosamente
        }
        //Update
        public async Task<bool> UpdateProductAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FindAsync(product.ProductId);

            if (existingProduct == null)
                return false;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Available = product.Available;
            existingProduct.PictureURL = product.PictureURL;
            existingProduct.ReviewRate = product.ReviewRate;

            await _dbContext.SaveChangesAsync();

            return true; //Producto actualizado exitosamente
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
