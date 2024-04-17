using API.Entities;

namespace API.Repository
{
    public interface IOrdersRepository
    {
        //Add
        Task CreateOrdersAsync(Order order);

        //Get
        Task<List<Order>> GetAllOrdersAsync();

        //Get by Id
        Task<Order> GetOrderByIdAsync(Guid orderId);

        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
