using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerBasketToCreateDto
    {
        [Required]
        public Guid Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
