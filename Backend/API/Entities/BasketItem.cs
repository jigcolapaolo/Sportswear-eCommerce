namespace API.Entities
{
    public class BasketItem
    {
        public Guid BasketItemId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }

        // Navigation property
        public CustomerBasket CustomerBasket { get; set; }

        // FK
        public Guid CustomerBasketId { get; set; }

        public BasketItem()
        {
            BasketItemId = Guid.NewGuid();
        }



    }
}