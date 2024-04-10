using API.Entities;

namespace API.Repository
{
    public interface IBasketItemRepository
    {
        // Get Item
        Task<BasketItem?> GetBasketItemAsync(Guid BasketItemId);

        // Post Item
        Task CreateBasketItemAsync(BasketItem basketItem);

        // Delete Item
        Task DeleteBasketItemAsync(Guid BasketItemId);
    }
}