using API.Entities;

namespace API.Dtos
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public decimal Subtotal { get; set; }

        public List<OrderItemToReturnDto> OrderItems { get; set; }


    }
}
