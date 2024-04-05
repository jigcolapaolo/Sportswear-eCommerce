using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class BasketItem
    {
        [Key]
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public required string Brand { get; set; }
        public required string Type { get; set; }
        
    }
}