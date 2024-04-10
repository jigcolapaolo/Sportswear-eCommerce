using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BasketItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BasketItem?> GetBasketItemAsync(Guid BasketItemId)
        {
            var basketItem = await _dbContext.BasketItem.FindAsync(BasketItemId);
            return basketItem;
        }

        public async Task CreateBasketItemAsync(BasketItem basketItem)
        {
            await _dbContext.BasketItem.AddAsync(basketItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBasketItemAsync(Guid BasketItemId)
        {
            var basketItem = await _dbContext.BasketItem.FindAsync(BasketItemId);

            if (basketItem == null)
            {
                throw new Exception($"El elemento con el ID '{BasketItemId}' no fue encontrado en la cesta.");
            }

            _dbContext.BasketItem.Remove(basketItem);
            await _dbContext.SaveChangesAsync();
        }

    }
}