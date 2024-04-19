using API.Entities;

namespace API.Repository
{
    public interface IBasketItemRepository
    {
        // Get Item
        Task<BasketItem> GetBasketItemAsync(Guid Id);

        // Post Item
        Task CreateBasketItemAsync(BasketItem Item);

        // Delete Item
        Task DeleteBasketItemAsync(Guid Id);
    }
}