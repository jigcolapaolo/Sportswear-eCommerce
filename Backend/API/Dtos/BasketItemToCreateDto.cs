using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemToCreateDto
    {
        [Required]
        public string? ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Type { get; set; }
    }
}
