namespace API.Entities
{
    public class OrderItems
    {
        public Guid OrderItemsId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation property
        public Orders Orders { get; set; }
        public Product Product { get; set; }

        public OrderItems() 
        { 
            OrderItemsId = Guid.NewGuid();
        }
    }
}
