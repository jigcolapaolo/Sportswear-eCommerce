using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerBasketToCreateDto
    {
        public List<BasketItemToCreateDto> BasketItems { get; set; } = new List<BasketItemToCreateDto>();
    }
}
