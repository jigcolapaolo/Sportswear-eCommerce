﻿namespace API.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public decimal Subtotal { get; set; }

        //TODO 1: Cambiar por un enum(Pendiente, pago recivido, error al realizar el pago)
        public bool Status { get; set; }

        // Navigation property
        public List<OrderItem> OrderItems { get; set; }

        //TODO 2: Iniciar las properiedas (Email, SubTotal, OrderItems, OrderDate) en el contructor
        public Order()
        {
            OrderId = Guid.NewGuid();
        }
    }
}
