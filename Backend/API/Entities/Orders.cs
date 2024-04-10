namespace API.Entities
{
    public class Orders
    {
        public Guid OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public decimal Subtotal { get; set; }
        public bool Status { get; set; }

        // Navigation property
        public List<OrderItems> OrderItems { get; set; }

        public Orders()
        {
            OrdersId = Guid.NewGuid();
        }
    }
}
