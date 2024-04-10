using API.Dtos;
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
        public async Task<List<Product>> GetProductsListAsync(ProductFilterDto filter)
        {
            var products = await _dbContext.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();

            //Filtros
            if (!string.IsNullOrEmpty(filter.Name))
                products = products.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter.BrandName))
                products = products.Where(p => p.Brand.Name.ToLower().Contains(filter.BrandName.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter.CategoryName))
                products = products.Where(p => p.Category.Name.ToLower().Contains(filter.CategoryName.ToLower())).ToList();

            if (filter.AudienceId != null)
                products = products.Where(p => p.Audience == (Audience)filter.AudienceId).ToList();

            if (filter.Available != null)
                products = products.Where(p => p.Available == filter.Available).ToList();

            //Orden
            //Precio
            if (filter.CheaperFirst.HasValue && !filter.AlphabeticalOrder.HasValue)
            {
                if (filter.CheaperFirst.Value)
                    products = products.OrderBy(p => p.Price).ToList();
                else
                    products = products.OrderByDescending(p => p.Price).ToList();
            }

            //Nombre
            if (filter.AlphabeticalOrder.HasValue && !filter.CheaperFirst.HasValue)
            {
                if (filter.AlphabeticalOrder.Value)
                    products = products.OrderBy(p => p.Name).ToList();
                else
                    products = products.OrderByDescending(p => p.Name).ToList();
            }

            return products;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            var product = await _dbContext.Products.Include(p => p.Brand).Include(p => p.Category)
                                                   .FirstOrDefaultAsync(p => p.ProductId == productId);

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
        public async Task<bool> UpdateProductAsync(Guid productId, ProductToUpdateDto productDto)
        {
            var existingProduct = await _dbContext.Products.FindAsync(productId);

            if (existingProduct == null)
                return false;

            if (productDto.Name != null)
                existingProduct.Name = productDto.Name;

            if (productDto.Description != null)
                existingProduct.Description = productDto.Description;

            if (productDto.Price != 0)
                existingProduct.Price = productDto.Price;

            if (productDto.Available.HasValue)
                existingProduct.Available = productDto.Available.Value;

            if (productDto.PictureURL != null)
                existingProduct.PictureURL = productDto.PictureURL;

            if (productDto.ReviewRate != 0)
                existingProduct.ReviewRate = productDto.ReviewRate;

            if (productDto.BrandId != Guid.Empty)
                existingProduct.BrandId = productDto.BrandId;

            if (productDto.CategoryId != Guid.Empty)
                existingProduct.CategoryId = productDto.CategoryId;

            if (productDto.AudienceId.HasValue)
                existingProduct.Audience = (Audience)productDto.AudienceId.Value;

            await _dbContext.SaveChangesAsync();

            return true; // Producto actualizado exitosamente
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
