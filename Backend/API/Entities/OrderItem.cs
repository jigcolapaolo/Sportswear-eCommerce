namespace API.Entities
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation property
        public Order Orders { get; set; }

        // TODO 3 Inicializar properties(Price, Quantity) en el  constructor
        public OrderItem() 
        { 
            OrderItemId = Guid.NewGuid();
        }
    }
}
