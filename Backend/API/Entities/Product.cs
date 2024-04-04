namespace API.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }


        // Navigation property
        public Brand Brand { get; set; }
        public Category Category { get; set; }


        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
