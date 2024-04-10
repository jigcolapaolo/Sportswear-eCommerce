using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrdersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //TODO 4 Implementar la logica para crear una order, revisar patrón unit of work
        public async Task CreateOrdersAsync(Order orders)
        {
            await _dbContext.Orders.AddAsync(orders);
        }

        //Get
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public Task<Product?> GetOrdersByIdAsync(Guid orderID)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
