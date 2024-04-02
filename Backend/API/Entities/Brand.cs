namespace API.Entities
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<Product> Products { get; set; }


        public Brand()
        {
            BrandId = Guid.NewGuid();
        }
    }
}
