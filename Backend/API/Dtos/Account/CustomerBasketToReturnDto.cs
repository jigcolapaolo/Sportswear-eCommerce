using API.Entities;

namespace API.Dtos.Account
{
    public class CustomerBasketToReturnDto
    {
        public Guid CustomerBasketId { get; set; }
        public List<BasketItemToReturnDto> BasketItems { get; set; } = new List<BasketItemToReturnDto>();
    }
}
