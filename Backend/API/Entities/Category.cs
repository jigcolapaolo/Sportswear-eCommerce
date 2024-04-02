namespace API.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }


        // Navigation property
        public List<Product> Products { get; set; }

    }
}
