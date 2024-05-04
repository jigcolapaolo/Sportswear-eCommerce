namespace API.Dtos
{
    public class OrderToCreateDTO
    {
        public Guid BasketId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public decimal Subtotal { get; set; }
        public bool Status { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }

    public class OrderItemDTO
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
