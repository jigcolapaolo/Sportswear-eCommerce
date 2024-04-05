using API.Entities;

namespace API.Repository
{
    public interface IBasketItemRepository
    {
        // Create Item
        Task CreateBasketItemAsync(BasketItem basketItem);

        // Save Changes
        Task SaveChangesAsync();
    }
}