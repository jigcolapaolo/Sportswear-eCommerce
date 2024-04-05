using API.Entities;

namespace API.Repository
{
    public interface IProductRepository
    {
        //Add
        Task CreateProductAsync(Product product);
        //Get
        Task<List<Product>> GetProductsByNameAsync(string name);
        //Delete
        Task<bool> DeleteProductAsync(Guid productId);
        //Update

        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
