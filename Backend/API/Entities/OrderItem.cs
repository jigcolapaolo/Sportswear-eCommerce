namespace API.Entities
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Llave foránea a Order
        public Guid OrderId { get; set; }
        // Navigation property
        public Order Order { get; set; }

        public OrderItem(decimal price, int quantity, Guid productId) 
        {
            OrderItemId = Guid.NewGuid();
            Price = price;
            Quantity = quantity;
            ProductId = productId;

        }
    }
}
