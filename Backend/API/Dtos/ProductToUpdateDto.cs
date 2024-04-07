namespace API.Dtos
{
    public class ProductToUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public string PictureURL { get; set; }
        public int ReviewRate { get; set; }
    }
}
