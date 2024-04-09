namespace API.Entities
{
    public enum Gender
    {
        Hombre,
        Mujer
    }

    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public string PictureURL { get; set; }
        public int ReviewRate { get; set; }
        public Gender Gender { get; set; }


        // Navigation property
        public Brand Brand { get; set; }
        public Category Category { get; set; }

        //Foreign Keys
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }


        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
