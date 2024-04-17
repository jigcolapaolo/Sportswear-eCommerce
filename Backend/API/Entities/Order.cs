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
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
