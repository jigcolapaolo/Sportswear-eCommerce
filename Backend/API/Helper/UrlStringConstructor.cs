using API.Entities;
using Microsoft.AspNetCore.Server;
using Microsoft.Identity.Client;
using Microsoft.OpenApi.Extensions;
using System.Drawing.Drawing2D;

namespace API.Helper
{
    public class UrlStringConstructor
    {

        public string UrlConstructor(Product product, Brand brand, Category category)
        {

            string imageFileName = $"Product-{brand.Name}-{category.Name}-{product.Audience}-{product.ProductId}";

            //La carpeta 'Images' está configurada para ser servida como archivos estáticos en wwwroot
            string imageUrl = $"/Images/Products/{brand.Name}/{imageFileName}";

            return imageUrl;
        }
    }
}
