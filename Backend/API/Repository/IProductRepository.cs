using API.Entities;

namespace API.Repository
{
    public interface IProductRepository
    {
        //New Product
        Task CreateProductAsync(Product product);
        Task<List<Product>> GetProductsByNameAsync(string name);

        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
