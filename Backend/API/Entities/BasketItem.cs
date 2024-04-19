using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class BasketItem
    {
        public Guid BasketItemId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }

        public BasketItem()
        {
            BasketItemId = Guid.NewGuid();
        }

        public CustomerBasket CustomerBasket { get; set; }
        public Guid CustomerBasketId { get; set; }
    }
}