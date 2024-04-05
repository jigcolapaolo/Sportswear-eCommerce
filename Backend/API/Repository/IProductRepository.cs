using API.Entities;

namespace API.Repository
{
    public interface IProductRepository
    {
        //New Product
        Task CreateProductAsync(Product product);

        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
