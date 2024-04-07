using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace API.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Brands
            var adidas = new Brand()
            {
                BrandId = new Guid("ea99a1a3-5b55-4da7-bf08-4081aeff7b1d"),
                Name = "Adidas"
            };
            var puma = new Brand()
            {
                BrandId = new Guid("9eeee855-eaa8-4828-b65c-4602ee02e058"),
                Name = "Puma"
            };
            var nike = new Brand()
            {
                BrandId = new Guid("590eb07c-2ace-496b-959f-3be70a4b03db"),
                Name = "Nike"
            };
            var reebok = new Brand()
            {
                BrandId = new Guid("7b0acaa3-5006-422a-a506-e3b59339fafa"),
                Name = "Reebok"
            };
            var fila = new Brand()
            {
                BrandId = new Guid("6d03d8f6-c4e9-4f83-b573-ed7277e39181"),
                Name = "Fila"
            };

            modelBuilder.Entity<Brand>().HasData(adidas, puma, nike, reebok, fila);

            //Categories
            var zapatillas = new Category()
            {
                CategoryId = new Guid("6c9b8c6d-4189-4898-916d-2f7d1d417be1"),
                Name = "Zapatillas"
            };
            var calzas = new Category()
            {
                CategoryId = new Guid("a9f1f13d-5a9a-412d-bb4d-0b55f495b9c6"),
                Name = "Calzas"
            };
            var buzos = new Category()
            {
                CategoryId = new Guid("9bbdae54-6c3d-477b-8c7e-fb3325d6fc96"),
                Name = "Buzos"
            };
            var tops = new Category()
            {
                CategoryId = new Guid("1fb94e63-ce4b-432e-b92e-dbbf7b6c77a8"),
                Name = "Tops"
            };
            var remeras = new Category()
            {
                CategoryId = new Guid("70018363-fd44-44e8-bed2-6dd7e2968022"),
                Name = "Remeras"
            };

            modelBuilder.Entity<Category>().HasData(zapatillas, calzas, buzos, tops, remeras);

            //Products
            var zapatillasAdidas = new Product()
            {
                ProductId = new Guid("4a908887-e7a4-4b1b-9f7e-32acdfad4c3d"),
                Name = "Zapatillas Adidas",
                Description = "Color Blanco",
                Price = 50000,
                Available = true,
                PictureURL = "",
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
            };
            var buzoFila = new Product()
            {
                ProductId = new Guid("2bb41d94-7894-4db9-b458-405d34abc009"),
                Name = "Buzo Fila",
                Description = "Color Azul",
                Price = 30000,
                Available = true,
                PictureURL = "",
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
            };
            var remeraNike = new Product()
            {
                ProductId = new Guid("33755bf6-4f1a-4e08-a544-4137e81507a7"),
                Name = "Remera Nike",
                Description = "Color Negro",
                Price = 20000,
                Available = true,
                PictureURL = "",
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
            };

            modelBuilder.Entity<Product>().HasData(zapatillasAdidas, buzoFila, remeraNike);

        }
    }
}
