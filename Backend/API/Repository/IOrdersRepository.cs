using API.Entities;

namespace API.Repository
{
    public interface IOrdersRepository
    {
        //Add
        Task CreateOrdersAsync(Orders orders);
        //Get
        Task<List<Orders>> GetAllOrdersAsync();
        Task<Product?> GetOrdersByIdAsync(Guid orderID);

        // Saves changes into the database
        Task SaveChangesAsync();

    }
}
