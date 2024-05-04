namespace API.Entities
{
    public class CustomerBasket
    {
        public Guid CustomerBasketId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public CustomerBasket()
        {
            CustomerBasketId = Guid.NewGuid();
        }
    }
}