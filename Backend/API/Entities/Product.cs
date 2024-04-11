namespace API.Entities
{
    public enum Audience
    {
        Hombre,
        Mujer,
        Niños
    }

    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int ReviewRate { get; set; }
        public Audience Audience { get; set; }
        


        // Navigation property
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public List<PictureUrl> PictureUrls { get; set; }

        //Foreign Keys
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }


        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
