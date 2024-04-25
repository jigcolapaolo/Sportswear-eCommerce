using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BasketItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerBasket?> GetBasketItemAsync(Guid BasketItemId)
        {
            var basketItem = await _dbContext.CustomerBaskets.Include(cb => cb.BasketItems).FirstOrDefaultAsync(cb => cb.CustomerBasketId == BasketItemId);
            return basketItem;
        }

        public async Task<CustomerBasket> CreateBasketItemAsync(CustomerBasket customerBasket)
        {
            await _dbContext.CustomerBaskets.AddAsync(customerBasket);
            await _dbContext.SaveChangesAsync();
            return await GetBasketItemAsync(customerBasket.CustomerBasketId);
        }

        public async Task DeleteBasketItemAsync(Guid BasketItemId)
        {
            var basket = await _dbContext.CustomerBaskets.FindAsync(BasketItemId);

            if (basket == null)
            {
                throw new Exception($"El elemento con el ID '{BasketItemId}' no fue encontrado en la cesta.");
            }

             _dbContext.CustomerBaskets.Remove(basket);
            await _dbContext.SaveChangesAsync();
        }

    }
}