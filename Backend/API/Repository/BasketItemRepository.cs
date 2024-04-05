using API.Entities;

namespace API.Repository
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BasketItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBasketItemAsync(BasketItem basketItem)
        {
            await _dbContext.BasketItem.AddAsync(basketItem);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}