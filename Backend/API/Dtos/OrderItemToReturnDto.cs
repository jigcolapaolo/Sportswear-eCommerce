namespace API.Dtos
{
    public class OrderItemToReturnDto
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
