using API.Entities;
using System.ComponentModel;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int ReviewRate { get; set; }
        public string BrandName {  get; set; }
        public string CategoryName { get; set; }
        public Audience Audience;
        public string AudienceType
        {
            get
            {
                return Audience.ToString();
            }
        }

        public List<PictureUrl> PictureUrls;
        public List<string> Urls
        {
            get
            {
                return PictureUrls.Select(picture => picture.Url).ToList();
            }
        }
    }
}
