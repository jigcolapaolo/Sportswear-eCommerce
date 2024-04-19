namespace API.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Llave foránea a Order
        public Guid OrderId { get; set; }
        // Navigation property
        public Order Order { get; set; }

        public OrderItem() 
        {
            Id = Guid.NewGuid();

        }
    }
}
