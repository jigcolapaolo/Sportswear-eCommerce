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

        //Add
        public async Task CreateOrdersAsync(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
        }

        //Get
        public async Task<List<Orders>> GetAllOrdersAsync()
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
