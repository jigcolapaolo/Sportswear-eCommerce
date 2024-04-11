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
            var products = await _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.PictureUrls)
                .ToListAsync();

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
            var product = await _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.PictureUrls)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            return product;
        }

        //Delete
        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var deletedProducts = await _dbContext.Products
                .Where(p => p.ProductId == productId)
                .ExecuteDeleteAsync();

            if (deletedProducts == 0)
                return false;

            await _dbContext.SaveChangesAsync();

            return true; //Producto eliminado exitosamente
        }

        //Update
        public async Task<bool> UpdateProductAsync(Guid productId, ProductToUpdateDto productDto)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (existingProduct == null)
                return false;

            //Mapeo y validaciones
            existingProduct.Name = productDto.Name ?? existingProduct.Name;
            existingProduct.Description = productDto.Description ?? existingProduct.Description;
            existingProduct.Price = productDto.Price != 0 ? productDto.Price : existingProduct.Price;
            existingProduct.Available = productDto.Available ?? existingProduct.Available;
            existingProduct.ReviewRate = productDto.ReviewRate != 0 ? productDto.ReviewRate : existingProduct.ReviewRate;
            existingProduct.BrandId = productDto.BrandId != Guid.Empty ? productDto.BrandId : existingProduct.BrandId;
            existingProduct.CategoryId = productDto.CategoryId != Guid.Empty ? productDto.CategoryId : existingProduct.CategoryId;
            existingProduct.Audience = productDto.AudienceId.HasValue ? (Audience)productDto.AudienceId.Value : existingProduct.Audience;


            await _dbContext.SaveChangesAsync();

            return true; // Producto actualizado exitosamente
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
