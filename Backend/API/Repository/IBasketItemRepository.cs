using API.Entities;

namespace API.Repository
{
    public interface IBasketItemRepository
    {
        // Get Item
        Task<CustomerBasket?> GetBasketItemAsync(Guid Id);

        // Post Item
        Task<CustomerBasket> CreateBasketItemAsync(CustomerBasket customerBasket);

        // Delete Item
        Task DeleteBasketItemAsync(Guid Id);
    }
}