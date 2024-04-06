using API.Entities;

namespace API.Dtos
{
    public class ProductToGetDto
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public string PictureURL { get; set; }
        public int ReviewRate { get; set; }

        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
