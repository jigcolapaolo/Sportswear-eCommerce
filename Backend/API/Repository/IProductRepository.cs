using API.Dtos;
using API.Entities;

namespace API.Repository
{
    public interface IProductRepository
    {
        //Add
        Task CreateProductAsync(Product product);
        //Get
        Task<List<Product>> GetProductsListAsync(ProductFilterDto filter);
        Task<Product?> GetProductByIdAsync(Guid productId);
        //Delete
        Task<bool> DeleteProductAsync(Guid productId);
        //Update
        Task<bool> UpdateProductAsync(Guid productId, ProductToUpdateDto productDto);
        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
