using API.Entities;

namespace API.Repository
{
    public interface IOrdersRepository
    {
        //Add
        Task CreateOrdersAsync(Order orders);
        //Get
        Task<List<Order>> GetAllOrdersAsync();
        Task<Product?> GetOrdersByIdAsync(Guid orderID);

        // Saves changes into the database
        Task SaveChangesAsync();

    }
}
