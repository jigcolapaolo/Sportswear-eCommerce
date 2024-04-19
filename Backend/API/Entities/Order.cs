namespace API.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public decimal Subtotal { get; set; }
        public bool Status { get; set; }



        // Navigation property for OrderItems
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            
        }

        public Order(List<OrderItem> orderItems, string email, decimal subtotal)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            Email = email;
            Subtotal = subtotal;
            OrderItems = orderItems;
        }
    }
}
