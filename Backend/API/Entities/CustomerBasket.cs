using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class CustomerBasket
    {
        public Guid CustomerBasketId { get; set; }
        public List<BasketItem> CustomerBasketItems { get; set; } = new List<BasketItem>();
    }
}