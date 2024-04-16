using API.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Dtos
{
    public class ProductToCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<string> PictureUrls { get; set; }
    }
}
