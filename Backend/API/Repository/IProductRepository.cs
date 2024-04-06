using API.Entities;

namespace API.Repository
{
    public interface IProductRepository
    {
        //Add
        Task CreateProductAsync(Product product);
        //Get
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<Product?> GetProductByIdAsync(Guid productId);
        //Delete
        Task<bool> DeleteProductAsync(Guid productId);
        //Update
        Task<bool> UpdateProductAsync(Product product);
        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
