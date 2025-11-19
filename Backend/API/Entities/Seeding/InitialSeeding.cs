using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using API.Helper;
using Microsoft.OpenApi.Extensions;

namespace API.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void ProgramSeed(ApplicationDbContext context)
        {

            UrlStringConstructor help = new();

            //Brands
            var adidas = new Brand()
            {
                BrandId = new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"),
                Name = "Adidas"
            };
            var puma = new Brand()
            {
                BrandId = new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"),
                Name = "Puma"
            };
            var nike = new Brand()
            {
                BrandId = new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"),
                Name = "Nike"
            };
            var reebok = new Brand()
            {
                BrandId = new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"),
                Name = "Reebok"
            };
            var fila = new Brand()
            {
                BrandId = new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"),
                Name = "Fila"
            };


            context.Brands.AddRange(adidas, puma, nike, reebok, fila);


            //Categories
            var zapatillas = new Category()
            {
                CategoryId = new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"),
                Name = "Zapatillas"
            };
            var calzas = new Category()
            {
                CategoryId = new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"),
                Name = "Calzas"
            };
            var buzos = new Category()
            {
                CategoryId = new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"),
                Name = "Buzos y Camperas"
            };
            var tops = new Category()
            {
                CategoryId = new Guid("62345277-d424-48ea-ace2-432e35c93d58"),
                Name = "Tops"
            };
            var remeras = new Category()
            {
                CategoryId = new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"),
                Name = "Remeras"
            };


            context.Categories.AddRange(zapatillas, calzas, buzos, tops, remeras);
            

            //Products

            var pictureUrls = new List<PictureUrl>();
            var products = new List<Product>();

            //Adidas
            //Buzos y Camperas
            var buzoAdidasHombre1 = new Product()
            {
                ProductId = new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"),
                Name = "Big Boss Buzo Adidas",
                Description = "Con capucha, color azul, logo naranja, para hombre.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasHombre1.ProductId
            });

            var buzoAdidasHombre2 = new Product()
            {
                ProductId = new Guid("3a13a2d8-956e-400d-9213-9893dd929897"),
                Name = "Buzo Adidas Essentials",
                Description = "Con capucha, color gris, felpa, para hombre.",
                Price = 110000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasHombre2.ProductId
            });

            var buzoAdidasMujer1 = new Product()
            {
                ProductId = new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"),
                Name = "Buzo Aeroready Adidas",
                Description = "Buzo corto color marrón, para mujer",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasMujer1.ProductId
            });

            var buzoAdidasMujer2 = new Product()
            {
                ProductId = new Guid("cc91c201-d57d-488e-8f16-c423234a8260"),
                Name = "Soft Luxe Buzo Adidas",
                Description = "Color azul rey, para mujer.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasMujer2.ProductId
            });

            var buzoAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"),
                Name = "Campera Adicolor Adidas",
                Description = "Campera color verde para niñas.",
                Price = 110000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });

            var buzoAdidasNiños1 = new Product()
            {
                ProductId = new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"),
                Name = "Buzo Adidas Originals",
                Description = "Color negro para niños.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiños1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiños1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasNiños1.ProductId
            });

            //Calzas
            var calzaAdidasHombre1 = new Product()
            {
                ProductId = new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"),
                Name = "Calzas Own the Run Adidas",
                Description = "Color negro para hombre.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(calzaAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasHombre1.ProductId
            });

            var calzaAdidasMujer1 = new Product()
            {
                ProductId = new Guid("1670707a-10e8-49d1-a071-fc427d319c10"),
                Name = "Calza Adicolor Adidas",
                Description = "Color negro para mujer.",
                Price = 72000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasMujer1.ProductId
            });

            var calzaAdidasMujer2 = new Product()
            {
                ProductId = new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"),
                Name = "Calza Adidas Rich",
                Description = "Color naranja con animal print para mujer.",
                Price = 95000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasMujer2.ProductId
            });

            //Remeras
            var remeraAdidasHombre1 = new Product()
            {
                ProductId = new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"),
                Name = "Remera Adidas Essentials",
                Description = "Color azul para hombre.",
                Price = 50000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasHombre1.ProductId
            });

            var remeraAdidasHombre2 = new Product()
            {
                ProductId = new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"),
                Name = "Remera Adidas Run",
                Description = "Color naranja para hombre.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasHombre2.ProductId
            });

            var remeraAdidasMujer1 = new Product()
            {
                ProductId = new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"),
                Name = "Remera Adidas Tiro",
                Description = "Color negro y lila para mujer.",
                Price = 60000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasMujer1.ProductId
            });

            var remeraAdidasMujer2 = new Product()
            {
                ProductId = new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"),
                Name = "Remera Adidas Run",
                Description = "Color salmón para mujer.",
                Price = 54500,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasMujer2.ProductId
            });

            var remeraAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"),
                Name = "Remera Adidas Essentials",
                Description = "Color rosa para niñas.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });

            var remeraAdidasNiños1 = new Product()
            {
                ProductId = new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"),
                Name = "Remera Trefoil Adidas",
                Description = "Color negro para niños.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasNiños1.ProductId
            });

            //Tops
            var topAdidasMujer1 = new Product()
            {
                ProductId = new Guid("fb25a719-2394-4987-b092-715e9f44005a"),
                Name = "Top Adidas Alpha",
                Description = "Color negro para mujer.",
                Price = 80000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-1.png",
                ProductId = topAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-2.png",
                ProductId = topAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-3.png",
                ProductId = topAdidasMujer1.ProductId
            });

            var topAdidasMujer2 = new Product()
            {
                ProductId = new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"),
                Name = "Top Adidas Essentials",
                Description = "Color negro para mujer.",
                Price = 65000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-1.png",
                ProductId = topAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-2.png",
                ProductId = topAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-3.png",
                ProductId = topAdidasMujer2.ProductId
            });

            //Zapatillas
            var zapatillasAdidasHombre1 = new Product()
            {
                ProductId = new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"),
                Name = "Zapatillas Fluidstreet Adidas",
                Description = "Color azul para hombre.",
                Price = 143000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });

            var zapatillasAdidasHombre2 = new Product()
            {
                ProductId = new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"),
                Name = "Zapatillas Adidas Galaxy",
                Description = "Color azul y naranja para hombre.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });

            var zapatillasAdidasMujer1 = new Product()
            {
                ProductId = new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"),
                Name = "Zapatillas Adidas Runfalcon",
                Description = "Color aguamarina para mujer.",
                Price = 132000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });

            var zapatillasAdidasMujer2 = new Product()
            {
                ProductId = new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"),
                Name = "Zapatillas Adidas Ultimateshow",
                Description = "Color celeste para mujer.",
                Price = 156000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });

            var zapatillasAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"),
                Name = "Zapatillas Adidas Altarun",
                Description = "Color rosa para niñas.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });

            var zapatillasAdidasNiños1 = new Product()
            {
                ProductId = new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"),
                Name = "Zapatillas Adidas Altasport",
                Description = "Color blanco y azul para niños.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });

            //Fila
            //Buzos y Camperas
            var buzoFilaHombre1 = new Product()
            {
                ProductId = new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"),
                Name = "Buzo Fila New Letter",
                Description = "Color negro para hombre.",
                Price = 142000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre1, fila, buzos) + "-1.png",
                ProductId = buzoFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre1, fila, buzos) + "-2.png",
                ProductId = buzoFilaHombre1.ProductId
            });

            var buzoFilaHombre2 = new Product()
            {
                ProductId = new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"),
                Name = "Buzo Fila Net",
                Description = "Color azul, blanco y rosa para hombre.",
                Price = 120500,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre2, fila, buzos) + "-1.png",
                ProductId = buzoFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre2, fila, buzos) + "-2.png",
                ProductId = buzoFilaHombre2.ProductId
            });

            var buzoFilaMujer1 = new Product()
            {
                ProductId = new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"),
                Name = "Buzo Crop Fila",
                Description = "Buzo corto color rosa para mujer.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-1.png",
                ProductId = buzoFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-2.png",
                ProductId = buzoFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-3.png",
                ProductId = buzoFilaMujer1.ProductId
            });

            var buzoFilaMujer2 = new Product()
            {
                ProductId = new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"),
                Name = "Buzo Fila Sweet",
                Description = "Color azul, blanco y rojo para mujer.",
                Price = 138000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer2, fila, buzos) + "-1.png",
                ProductId = buzoFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer2, fila, buzos) + "-2.png",
                ProductId = buzoFilaMujer2.ProductId
            });

            //Calzas
            var calzaFilaHombre1 = new Product()
            {
                ProductId = new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"),
                Name = "Calza Flex Fila",
                Description = "Color negro para hombre.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(calzaFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaHombre1, fila, calzas) + "-1.png",
                ProductId = calzaFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaHombre1, fila, calzas) + "-2.png",
                ProductId = calzaFilaHombre1.ProductId
            });

            var calzaFilaMujer1 = new Product()
            {
                ProductId = new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"),
                Name = "Calza Fila Flat",
                Description = "Calza corta, color negro para mujer.",
                Price = 48000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-1.png",
                ProductId = calzaFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-2.png",
                ProductId = calzaFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-3.png",
                ProductId = calzaFilaMujer1.ProductId
            });

            var calzaFilaMujer2 = new Product()
            {
                ProductId = new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"),
                Name = "Calza Fila Tenis",
                Description = "Color gris para mujer.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-1.png",
                ProductId = calzaFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-2.png",
                ProductId = calzaFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-3.png",
                ProductId = calzaFilaMujer2.ProductId
            });

            //Remeras
            var remeraFilaHombre1 = new Product()
            {
                ProductId = new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"),
                Name = "Remera Australian Fila",
                Description = "Color celeste para hombre.",
                Price = 61000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-1.png",
                ProductId = remeraFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-2.png",
                ProductId = remeraFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-3.png",
                ProductId = remeraFilaHombre1.ProductId
            });

            var remeraFilaHombre2 = new Product()
            {
                ProductId = new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"),
                Name = "Remera G Fila",
                Description = "Color azul para hombre.",
                Price = 60500,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-1.png",
                ProductId = remeraFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-2.png",
                ProductId = remeraFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-3.png",
                ProductId = remeraFilaHombre2.ProductId
            });

            var remeraFilaMujer1 = new Product()
            {
                ProductId = new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"),
                Name = "Remera Fila Basic",
                Description = "Color negro para mujer.",
                Price = 48000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-1.png",
                ProductId = remeraFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-2.png",
                ProductId = remeraFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-3.png",
                ProductId = remeraFilaMujer1.ProductId
            });

            var remeraFilaMujer2 = new Product()
            {
                ProductId = new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"),
                Name = "Remera Mindfull Fila",
                Description = "Remera manga larga, color negro para mujer.",
                Price = 57000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-1.png",
                ProductId = remeraFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-2.png",
                ProductId = remeraFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-3.png",
                ProductId = remeraFilaMujer2.ProductId
            });

            var remeraFilaNiñas1 = new Product()
            {
                ProductId = new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"),
                Name = "Remera Vector Fila",
                Description = "Color lila para niñas.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraFilaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-1.png",
                ProductId = remeraFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-2.png",
                ProductId = remeraFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-3.png",
                ProductId = remeraFilaNiñas1.ProductId
            });

            var remerafilaNiños1 = new Product()
            {
                ProductId = new Guid("acce2896-28b7-4995-a8e6-a5f800362499"),
                Name = "Remera Fila Basic",
                Description = "Color blanco para niños.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remerafilaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-1.png",
                ProductId = remerafilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-2.png",
                ProductId = remerafilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-3.png",
                ProductId = remerafilaNiños1.ProductId
            });

            //Tops
            var topFilaMujer1 = new Product()
            {
                ProductId = new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"),
                Name = "Top Fila Essentials",
                Description = "Color blanco para mujer.",
                Price = 81000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-1.png",
                ProductId = topFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-2.png",
                ProductId = topFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-3.png",
                ProductId = topFilaMujer1.ProductId
            });

            var topFilaMujer2 = new Product()
            {
                ProductId = new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"),
                Name = "Top Fila Essentials",
                Description = "Color gris para mujer.",
                Price = 87000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-1.png",
                ProductId = topFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-2.png",
                ProductId = topFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-3.png",
                ProductId = topFilaMujer2.ProductId
            });

            //Zapatillas
            var zapatillasFilaHombre1 = new Product()
            {
                ProductId = new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"),
                Name = "Zapatillas Magnus Fila",
                Description = "Color azul, verde y blanco para hombre.",
                Price = 178000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });

            var zapatillasFilaHombre2 = new Product()
            {
                ProductId = new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"),
                Name = "Zapatillas Racer One Fila",
                Description = "Color negro y gris para hombre",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });

            var zapatillasFilaMujer1 = new Product()
            {
                ProductId = new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"),
                Name = "Zapatillas Fila Orbit",
                Description = "Color rosa para mujer.",
                Price = 174000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });

            var zapatillasFilaMujer2 = new Product()
            {
                ProductId = new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"),
                Name = "Zapatillas Racer One Fila",
                Description = "Color beige y rosa para mujer.",
                Price = 158000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });

            var zapatillasFilaNiñas1 = new Product()
            {
                ProductId = new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"),
                Name = "Zapatillas Disruptor Fila",
                Description = "Color rosa para niñas.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasFilaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });

            var zapatillasFilaNiños1 = new Product()
            {
                ProductId = new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"),
                Name = "Zapatillas Vulcan Fila",
                Description = "Color blanco, negro y rojo para niños.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasFilaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });

            //Nike
            //Buzos y Camperas
            var buzoNikeHombre1 = new Product()
            {
                ProductId = new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"),
                Name = "Buzo Nike Sportwear",
                Description = "Color turquesa oscuro para hombre.",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-1.png",
                ProductId = buzoNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-2.png",
                ProductId = buzoNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-3.png",
                ProductId = buzoNikeHombre1.ProductId
            });

            var buzoNikeMujer1 = new Product()
            {
                ProductId = new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"),
                Name = "Buzo Nike Flex",
                Description = "Color negro para mujer.",
                Price = 180000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-1.png",
                ProductId = buzoNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-2.png",
                ProductId = buzoNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-3.png",
                ProductId = buzoNikeMujer1.ProductId
            });

            var buzoNikeMujer2 = new Product()
            {
                ProductId = new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"),
                Name = "Buzo Nike SportOn",
                Description = "Color negro para mujer.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-1.png",
                ProductId = buzoNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-2.png",
                ProductId = buzoNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-3.png",
                ProductId = buzoNikeMujer2.ProductId
            });

            var buzoNikeNiñas1 = new Product()
            {
                ProductId = new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"),
                Name = "Buzo Nike Mini",
                Description = "Color negro para niñas.",
                Price = 123000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-1.png",
                ProductId = buzoNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-2.png",
                ProductId = buzoNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-3.png",
                ProductId = buzoNikeNiñas1.ProductId
            });

            var buzoNikeNiños1 = new Product()
            {
                ProductId = new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"),
                Name = "Campera Nike Mini",
                Description = "Color negro para niños.",
                Price = 125000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-1.png",
                ProductId = buzoNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-2.png",
                ProductId = buzoNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-3.png",
                ProductId = buzoNikeNiños1.ProductId
            });


            //Calzas
            var calzaNikeMujer1 = new Product()
            {
                ProductId = new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"),
                Name = "Calza Nike Air",
                Description = "Color negro para mujer.",
                Price = 83000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-1.png",
                ProductId = calzaNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-2.png",
                ProductId = calzaNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-3.png",
                ProductId = calzaNikeMujer1.ProductId
            });

            var calzaNikeMujer2 = new Product()
            {
                ProductId = new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"),
                Name = "Calza Nike Essentials",
                Description = "Calza corta, color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-1.png",
                ProductId = calzaNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-2.png",
                ProductId = calzaNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-3.png",
                ProductId = calzaNikeMujer2.ProductId
            });

            //Remeras
            var remeraNikeHombre1 = new Product()
            {
                ProductId = new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"),
                Name = "Remeras Nike SportOn",
                Description = "Color blanco para hombre.",
                Price = 68000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-1.png",
                ProductId = remeraNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-2.png",
                ProductId = remeraNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-3.png",
                ProductId = remeraNikeHombre1.ProductId
            });

            var remeraNikeHombre2 = new Product()
            {
                ProductId = new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"),
                Name = "Remera Nike Dry Fit",
                Description = "Remera manga larga, color negro para hombre.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraNikeHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-1.png",
                ProductId = remeraNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-2.png",
                ProductId = remeraNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-3.png",
                ProductId = remeraNikeHombre2.ProductId
            });

            var remeraNikeMujer1 = new Product()
            {
                ProductId = new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"),
                Name = "Remera Nike Dry Fit",
                Description = "Color verde claro para mujer.",
                Price = 60500,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-1.png",
                ProductId = remeraNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-2.png",
                ProductId = remeraNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-3.png",
                ProductId = remeraNikeMujer1.ProductId
            });

            var remeraNikeMujer2 = new Product()
            {
                ProductId = new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"),
                Name = "Remera Nike Miler",
                Description = "Color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-1.png",
                ProductId = remeraNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-2.png",
                ProductId = remeraNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-3.png",
                ProductId = remeraNikeMujer2.ProductId
            });

            var remeraNikeNiñas1 = new Product()
            {
                ProductId = new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"),
                Name = "Remera Nike Sportswear",
                Description = "Color blanco para niñas.",
                Price = 44000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-1.png",
                ProductId = remeraNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-2.png",
                ProductId = remeraNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-3.png",
                ProductId = remeraNikeNiñas1.ProductId
            });

            var remeraNikeNiños1 = new Product()
            {
                ProductId = new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"),
                Name = "Remera Nike Basic",
                Description = "Remera manga larga, color negro para niños.",
                Price = 44000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-1.png",
                ProductId = remeraNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-2.png",
                ProductId = remeraNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-3.png",
                ProductId = remeraNikeNiños1.ProductId
            });

            //Tops
            var topNikeMujer1 = new Product()
            {
                ProductId = new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"),
                Name = "Top Nike Pro",
                Description = "Color negro para mujer.",
                Price = 81000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-1.png",
                ProductId = topNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-2.png",
                ProductId = topNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-3.png",
                ProductId = topNikeMujer1.ProductId
            });

            var topNikeMujer2 = new Product()
            {
                ProductId = new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"),
                Name = "Top Nike Sportswear",
                Description = "Color beige para mujer.",
                Price = 82000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-1.png",
                ProductId = topNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-2.png",
                ProductId = topNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-3.png",
                ProductId = topNikeMujer2.ProductId
            });

            //Zapatillas
            var zapatillasNikeHombre1 = new Product()
            {
                ProductId = new Guid("700fb128-5017-41ca-9221-765c3c3d9629"),
                Name = "Zapatillas Nike Flex",
                Description = "Color negro para hombre.",
                Price = 168000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });

            var zapatillasNikeHombre2 = new Product()
            {
                ProductId = new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"),
                Name = "Zapatillas Nike Legend Essential",
                Description = "Color negro, azul y beige para hombre.",
                Price = 175000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasNikeHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });

            var zapatillasNikeMujer1 = new Product()
            {
                ProductId = new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"),
                Name = "Zapatillas Nike Air Pegasus",
                Description = "Color blanco y rosa para mujer.",
                Price = 160000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });

            var zapatillasNikeMujer2 = new Product()
            {
                ProductId = new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"),
                Name = "Zapatillas Nike Trainer",
                Description = "Color negro, gris y lavanda para mujer.",
                Price = 185000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });

            var zapatillasNikeNiñas1 = new Product()
            {
                ProductId = new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"),
                Name = "Zapatillas Nike Pico",
                Description = "Color blanco y rosa para niñas.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });

            var zapatillasNikeNiños1 = new Product()
            {
                ProductId = new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"),
                Name = "Zapatillas Nike Hustle",
                Description = "Color azul y negro para niños.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });

            //Puma
            //Buzos y Camperas
            var buzoPumaHombre1 = new Product()
            {
                ProductId = new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"),
                Name = "Buzo Puma Green",
                Description = "Color verde claro para hombre.",
                Price = 174000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-1.png",
                ProductId = buzoPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-2.png",
                ProductId = buzoPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-3.png",
                ProductId = buzoPumaHombre1.ProductId
            });

            var buzoPumaHombre2 = new Product()
            {
                ProductId = new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"),
                Name = "Buzo Puma Black",
                Description = "Color negro para hombre.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-1.png",
                ProductId = buzoPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-2.png",
                ProductId = buzoPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-3.png",
                ProductId = buzoPumaHombre2.ProductId
            });

            var buzoPumaMujer1 = new Product()
            {
                ProductId = new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"),
                Name = "Buzo Puma Black",
                Description = "Color negro para mujer.",
                Price = 160500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-1.png",
                ProductId = buzoPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-2.png",
                ProductId = buzoPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-3.png",
                ProductId = buzoPumaMujer1.ProductId
            });

            var buzoPumaMujer2 = new Product()
            {
                ProductId = new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"),
                Name = "Buzo Puma Mili",
                Description = "Color verde militar para mujer.",
                Price = 145000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-1.png",
                ProductId = buzoPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-2.png",
                ProductId = buzoPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-3.png",
                ProductId = buzoPumaMujer2.ProductId
            });

            var buzoPumaNiñas1 = new Product()
            {
                ProductId = new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"),
                Name = "Buzo Puma Mini",
                Description = "Color rosa para niñas.",
                Price = 110500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-1.png",
                ProductId = buzoPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-2.png",
                ProductId = buzoPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-3.png",
                ProductId = buzoPumaNiñas1.ProductId
            });

            var buzoPumaNiños1 = new Product()
            {
                ProductId = new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"),
                Name = "Buzo Puma Mini",
                Description = "Color negro y amarillo para niños.",
                Price = 110500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-1.png",
                ProductId = buzoPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-2.png",
                ProductId = buzoPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-3.png",
                ProductId = buzoPumaNiños1.ProductId
            });

            //Calzas
            var calzaPumaMujer1 = new Product()
            {
                ProductId = new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"),
                Name = "Calza Puma Active",
                Description = "Color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer1, puma, calzas) + "-1.png",
                ProductId = calzaPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer1, puma, calzas) + "-2.png",
                ProductId = calzaPumaMujer1.ProductId
            });

            var calzaPumaMujer2 = new Product()
            {
                ProductId = new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"),
                Name = "Calza Puma Run",
                Description = "Color bordo y blanco para mujer.",
                Price = 55000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-1.png",
                ProductId = calzaPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-2.png",
                ProductId = calzaPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-3.png",
                ProductId = calzaPumaMujer2.ProductId
            });

            //Remeras
            var remeraPumaHombre1 = new Product()
            {
                ProductId = new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"),
                Name = "Remera Puma Core",
                Description = "Color negro para hombre.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-1.png",
                ProductId = remeraPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-2.png",
                ProductId = remeraPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-3.png",
                ProductId = remeraPumaHombre1.ProductId
            });

            var remeraPumaHombre2 = new Product()
            {
                ProductId = new Guid("a64d4099-646e-4691-9e48-76726984e83d"),
                Name = "Remera Puma Rudagon",
                Description = "Color negro para hombre.",
                Price = 53500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-1.png",
                ProductId = remeraPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-2.png",
                ProductId = remeraPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-3.png",
                ProductId = remeraPumaHombre2.ProductId
            });

            var remeraPumaMujer1 = new Product()
            {
                ProductId = new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"),
                Name = "Remera Puma Classics",
                Description = "Color blanco para mujer.",
                Price = 59000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-1.png",
                ProductId = remeraPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-2.png",
                ProductId = remeraPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-3.png",
                ProductId = remeraPumaMujer1.ProductId
            });

            var remeraPumaMujer2 = new Product()
            {
                ProductId = new Guid("0c92c422-5970-430e-a2b7-800313abf519"),
                Name = "Remera Puma Classics",
                Description = "Color negro para mujer.",
                Price = 57000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer2, puma, remeras) + "-1.png",
                ProductId = remeraPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer2, puma, remeras) + "-2.png",
                ProductId = remeraPumaMujer2.ProductId
            });

            var remeraPumaNiñas1 = new Product()
            {
                ProductId = new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"),
                Name = "Remera Puma x Bob Esponja",
                Description = "Color amarillo para niñas.",
                Price = 45000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-1.png",
                ProductId = remeraPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-2.png",
                ProductId = remeraPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-3.png",
                ProductId = remeraPumaNiñas1.ProductId
            });

            var remeraPumaNiños1 = new Product()
            {
                ProductId = new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"),
                Name = "Remera Puma x Bob Esponja",
                Description = "Color blanco para niños.",
                Price = 45000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-1.png",
                ProductId = remeraPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-2.png",
                ProductId = remeraPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-3.png",
                ProductId = remeraPumaNiños1.ProductId
            });

            //Tops
            var topPumaMujer1 = new Product()
            {
                ProductId = new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"),
                Name = "Top Puma Keeps",
                Description = "Color negro para mujer.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-1.png",
                ProductId = topPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-2.png",
                ProductId = topPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-3.png",
                ProductId = topPumaMujer1.ProductId
            });

            var topPumaMujer2 = new Product()
            {
                ProductId = new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"),
                Name = "Top Puma Mid Impact",
                Description = "Color negro para mujer.",
                Price = 76000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-1.png",
                ProductId = topPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-2.png",
                ProductId = topPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-3.png",
                ProductId = topPumaMujer2.ProductId
            });

            //Zapatillas
            var zapatillasPumaHombre1 = new Product()
            {
                ProductId = new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"),
                Name = "Zapatillas Puma Comet",
                Description = "Color rojo para hombre.",
                Price = 189000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });

            var zapatillasPumaHombre2 = new Product()
            {
                ProductId = new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"),
                Name = "Zapatillas Puma Taper",
                Description = "Color blanco y negro para hombre.",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });

            var zapatillasPumaMujer1 = new Product()
            {
                ProductId = new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"),
                Name = "Zapatillas Puma Flyer Runner",
                Description = "Color lavanda para mujer.",
                Price = 178000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });

            var zapatillasPumaMujer2 = new Product()
            {
                ProductId = new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"),
                Name = "Zapatillas Puma Platinum",
                Description = "Color negro, blanco y beige para mujer.",
                Price = 165000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });

            var zapatillasPumaNiñas1 = new Product()
            {
                ProductId = new Guid("f58b815e-12b1-4499-8f04-bb6725034853"),
                Name = "Zapatillas Puma Comet",
                Description = "Color rosa para niñas.",
                Price = 113000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });

            var zapatillasPumaNiños1 = new Product()
            {
                ProductId = new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"),
                Name = "Zapatillas Puma Rebound",
                Description = "Color negro y blanco para niños.",
                Price = 113000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiños1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiños1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });

            //Reebok
            //Buzos y Camperas
            var buzoReebokHombre1 = new Product()
            {
                ProductId = new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"),
                Name = "Buzo Reebok Sportswear",
                Description = "Color negro para hombre.",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-1.png",
                ProductId = buzoReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-2.png",
                ProductId = buzoReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-3.png",
                ProductId = buzoReebokHombre1.ProductId
            });

            var buzoReebokHombre2 = new Product()
            {
                ProductId = new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"),
                Name = "Buzo Reebok VTM",
                Description = "Color azul para hombre.",
                Price = 173000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-1.png",
                ProductId = buzoReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-2.png",
                ProductId = buzoReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-3.png",
                ProductId = buzoReebokHombre2.ProductId
            });

            var buzoReebokMujer1 = new Product()
            {
                ProductId = new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"),
                Name = "Buzo Reebok VTF",
                Description = "Color negro para mujer.",
                Price = 169000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer1, reebok, buzos) + "-1.png",
                ProductId = buzoReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer1, reebok, buzos) + "-2.png",
                ProductId = buzoReebokMujer1.ProductId
            });

            var buzoReebokMujer2 = new Product()
            {
                ProductId = new Guid("f94933b0-b851-41ec-85a6-62b172aad404"),
                Name = "Buzo Reebok Sportswear",
                Description = "Color negro para mujer.",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-1.png",
                ProductId = buzoReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-2.png",
                ProductId = buzoReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-3.png",
                ProductId = buzoReebokMujer2.ProductId
            });

            //Calzas
            var calzaReebokMujer1 = new Product()
            {
                ProductId = new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"),
                Name = "Calza Reebok Fit",
                Description = "Calza corta, color negro para mujer.",
                Price = 49500,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-1.png",
                ProductId = calzaReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-2.png",
                ProductId = calzaReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-3.png",
                ProductId = calzaReebokMujer1.ProductId
            });

            var calzaReebokMujer2 = new Product()
            {
                ProductId = new Guid("c7160512-a504-4d24-bb65-e8357e591f89"),
                Name = "Calza Reebok Workout Ready",
                Description = "Color gris camo para mujer.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-1.png",
                ProductId = calzaReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-2.png",
                ProductId = calzaReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-3.png",
                ProductId = calzaReebokMujer2.ProductId
            });

            //Remeras
            var remeraReebokHombre1 = new Product()
            {
                ProductId = new Guid("418f8acd-c640-40d6-8f1d-084465af5300"),
                Name = "Remera Reebok Graphic Series",
                Description = "Color negro para hombre.",
                Price = 64500,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-1.png",
                ProductId = remeraReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-2.png",
                ProductId = remeraReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-3.png",
                ProductId = remeraReebokHombre1.ProductId
            });

            var remeraReebokHombre2 = new Product()
            {
                ProductId = new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"),
                Name = "Remera Reebok Classic Soft",
                Description = "Color gris para hombre.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-1.png",
                ProductId = remeraReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-2.png",
                ProductId = remeraReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-3.png",
                ProductId = remeraReebokHombre2.ProductId
            });

            var remeraReebokMujer1 = new Product()
            {
                ProductId = new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"),
                Name = "Remera Reebok Classic",
                Description = "Color celeste para mujer.",
                Price = 59000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-1.png",
                ProductId = remeraReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-2.png",
                ProductId = remeraReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-3.png",
                ProductId = remeraReebokMujer1.ProductId
            });

            var remeraReebokMujer2 = new Product()
            {
                ProductId = new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"),
                Name = "Remera Reebok Burnout",
                Description = "Color negro para mujer.",
                Price = 69000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-1.png",
                ProductId = remeraReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-2.png",
                ProductId = remeraReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-3.png",
                ProductId = remeraReebokMujer2.ProductId
            });

            //Tops
            var topReebokMujer1 = new Product()
            {
                ProductId = new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"),
                Name = "Top Reebok ColorFit",
                Description = "Color aguamarina para mujer.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-1.png",
                ProductId = topReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-2.png",
                ProductId = topReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-3.png",
                ProductId = topReebokMujer1.ProductId
            });

            var topReebokMujer2 = new Product()
            {
                ProductId = new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"),
                Name = "Top Reebok Flex",
                Description = "Color negro para mujer.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-1.png",
                ProductId = topReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-2.png",
                ProductId = topReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-3.png",
                ProductId = topReebokMujer2.ProductId
            });

            //Zapatillas
            var zapatillasReebokHombre1 = new Product()
            {
                ProductId = new Guid("39e394fc-1afe-4969-8064-bc196834af14"),
                Name = "Zapatillas Reebok Flexagon",
                Description = "Color gris y blanco para hombre.",
                Price = 153000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });

            var zapatillasReebokHombre2 = new Product()
            {
                ProductId = new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"),
                Name = "Zapatillas Reebok Forever",
                Description = "Color celeste y negro para hombre.",
                Price = 169000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });

            var zapatillasReebokMujer1 = new Product()
            {
                ProductId = new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"),
                Name = "Zapatillas Reebok Liquifect",
                Description = "Color salmón para mujer.",
                Price = 193000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokMujer1.ProductId
            });

            var zapatillasReebokMujer2 = new Product()
            {
                ProductId = new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"),
                Name = "Zapatillas Reebok Lite Plus",
                Description = "Color azul y rosa para mujer.",
                Price = 142000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });

            var zapatillasReebokNiñas1 = new Product()
            {
                ProductId = new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"),
                Name = "Zapatillas Reebok Classic Jogger",
                Description = "Color blanco y rosa para niñas.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasReebokNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });

            var zapatillasReebokNiños1 = new Product()
            {
                ProductId = new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"),
                Name = "Zapatillas Reebok Royal",
                Description = "Color azul, blanco y amarillo para niños.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasReebokNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });



            context.Products.AddRange(products.ToArray());
            context.PictureUrls.AddRange(pictureUrls.ToArray());
        }

        public static void Seed(ModelBuilder modelBuilder)
        {

            UrlStringConstructor help = new();

            //Brands
            var adidas = new Brand()
            {
                BrandId = new Guid("0656c049-a76d-486d-9a4c-b731a43367d9"),
                Name = "Adidas"
            };
            var puma = new Brand()
            {
                BrandId = new Guid("7ba3bd5f-6b65-46f9-b2fc-5a344758b8b4"),
                Name = "Puma"
            };
            var nike = new Brand()
            {
                BrandId = new Guid("bc2d9ffd-0b06-4b2f-9b3b-a7685b5ea963"),
                Name = "Nike"
            };
            var reebok = new Brand()
            {
                BrandId = new Guid("f7c03831-1203-4686-83e1-ebb468c16c45"),
                Name = "Reebok"
            };
            var fila = new Brand()
            {
                BrandId = new Guid("33540e7e-f7a3-4d86-86f3-24bd61cd71db"),
                Name = "Fila"
            };

            modelBuilder.Entity<Brand>().HasData(adidas, puma, nike, reebok, fila);

            //Categories
            var zapatillas = new Category()
            {
                CategoryId = new Guid("02d4111b-cb81-497a-9dde-34a5ea007381"),
                Name = "Zapatillas"
            };
            var calzas = new Category()
            {
                CategoryId = new Guid("11863d5f-d94e-4b3c-9f57-b8e7fe2d0608"),
                Name = "Calzas"
            };
            var buzos = new Category()
            {
                CategoryId = new Guid("538c69b0-d322-4ce5-8b60-dc2355f25681"),
                Name = "Buzos y Camperas"
            };
            var tops = new Category()
            {
                CategoryId = new Guid("62345277-d424-48ea-ace2-432e35c93d58"),
                Name = "Tops"
            };
            var remeras = new Category()
            {
                CategoryId = new Guid("30012ff3-1513-4e78-b242-591fd6058ffe"),
                Name = "Remeras"
            };

            modelBuilder.Entity<Category>().HasData(zapatillas, calzas, buzos, tops, remeras);

            //Products

            var pictureUrls = new List<PictureUrl>();
            var products = new List<Product>();

            //Adidas
            //Buzos y Camperas
            var buzoAdidasHombre1 = new Product()
            {
                ProductId = new Guid("875cf1ea-ad27-409b-a03e-51b2a3f4bb6c"),
                Name = "Big Boss Buzo Adidas",
                Description = "Con capucha, color azul, logo naranja, para hombre.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            { 
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasHombre1.ProductId 
            });
            pictureUrls.Add(new PictureUrl 
            { 
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasHombre1.ProductId 
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasHombre1.ProductId
            });

            var buzoAdidasHombre2 = new Product()
            {
                ProductId = new Guid("3a13a2d8-956e-400d-9213-9893dd929897"),
                Name = "Buzo Adidas Essentials",
                Description = "Con capucha, color gris, felpa, para hombre.",
                Price = 110000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasHombre2, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasHombre2.ProductId
            });

            var buzoAdidasMujer1 = new Product()
            {
                ProductId = new Guid("2df90aaf-900c-410a-bf6b-3c8da468f600"),
                Name = "Buzo Aeroready Adidas",
                Description = "Buzo corto color marrón, para mujer",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasMujer1.ProductId
            });

            var buzoAdidasMujer2 = new Product()
            {
                ProductId = new Guid("cc91c201-d57d-488e-8f16-c423234a8260"),
                Name = "Soft Luxe Buzo Adidas",
                Description = "Color azul rey, para mujer.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasMujer2, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasMujer2.ProductId
            });

            var buzoAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("e3676b6a-190b-4e72-bb64-ca5c636f321e"),
                Name = "Campera Adicolor Adidas",
                Description = "Campera color verde para niñas.",
                Price = 110000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiñas1, adidas, buzos) + "-3.png",
                ProductId = buzoAdidasNiñas1.ProductId
            });

            var buzoAdidasNiños1 = new Product()
            {
                ProductId = new Guid("4287b952-5edc-43bb-bb61-fc42d2e51f14"),
                Name = "Buzo Adidas Originals",
                Description = "Color negro para niños.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiños1, adidas, buzos) + "-1.png",
                ProductId = buzoAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoAdidasNiños1, adidas, buzos) + "-2.png",
                ProductId = buzoAdidasNiños1.ProductId
            });

            //Calzas
            var calzaAdidasHombre1 = new Product()
            {
                ProductId = new Guid("6c62b16f-af56-4a69-aa7d-f769c70facb0"),
                Name = "Calzas Own the Run Adidas",
                Description = "Color negro para hombre.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(calzaAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasHombre1, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasHombre1.ProductId
            });

            var calzaAdidasMujer1 = new Product()
            {
                ProductId = new Guid("1670707a-10e8-49d1-a071-fc427d319c10"),
                Name = "Calza Adicolor Adidas",
                Description = "Color negro para mujer.",
                Price = 72000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer1, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasMujer1.ProductId
            });

            var calzaAdidasMujer2 = new Product()
            {
                ProductId = new Guid("49f8f920-4610-440f-ba71-a1c1ed6ddb8d"),
                Name = "Calza Adidas Rich",
                Description = "Color naranja con animal print para mujer.",
                Price = 95000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-1.png",
                ProductId = calzaAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-2.png",
                ProductId = calzaAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaAdidasMujer2, adidas, calzas) + "-3.png",
                ProductId = calzaAdidasMujer2.ProductId
            });

            //Remeras
            var remeraAdidasHombre1 = new Product()
            {
                ProductId = new Guid("058f6760-7751-440c-bfcd-dcb0cf16fe4e"),
                Name = "Remera Adidas Essentials",
                Description = "Color azul para hombre.",
                Price = 50000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasHombre1.ProductId
            });

            var remeraAdidasHombre2 = new Product()
            {
                ProductId = new Guid("a08a0c1c-f882-4a8e-af0b-b889e87cc93d"),
                Name = "Remera Adidas Run",
                Description = "Color naranja para hombre.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasHombre2, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasHombre2.ProductId
            });

            var remeraAdidasMujer1 = new Product()
            {
                ProductId = new Guid("29c7841e-2f15-4bcd-8ae3-bb3a8bce478d"),
                Name = "Remera Adidas Tiro",
                Description = "Color negro y lila para mujer.",
                Price = 60000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasMujer1.ProductId
            });

            var remeraAdidasMujer2 = new Product()
            {
                ProductId = new Guid("2962fbca-53b3-4393-88ad-2642a49b8492"),
                Name = "Remera Adidas Run",
                Description = "Color salmón para mujer.",
                Price = 54500,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasMujer2, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasMujer2.ProductId
            });

            var remeraAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("7cd84802-c771-4d1c-b17a-320d05ae81b8"),
                Name = "Remera Adidas Essentials",
                Description = "Color rosa para niñas.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiñas1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasNiñas1.ProductId
            });

            var remeraAdidasNiños1 = new Product()
            {
                ProductId = new Guid("f5b76376-3dd6-4cd0-936f-0391703cec10"),
                Name = "Remera Trefoil Adidas",
                Description = "Color negro para niños.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-1.png",
                ProductId = remeraAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-2.png",
                ProductId = remeraAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraAdidasNiños1, adidas, remeras) + "-3.png",
                ProductId = remeraAdidasNiños1.ProductId
            });

            //Tops
            var topAdidasMujer1 = new Product()
            {
                ProductId = new Guid("fb25a719-2394-4987-b092-715e9f44005a"),
                Name = "Top Adidas Alpha",
                Description = "Color negro para mujer.",
                Price = 80000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-1.png",
                ProductId = topAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-2.png",
                ProductId = topAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer1, adidas, tops) + "-3.png",
                ProductId = topAdidasMujer1.ProductId
            });

            var topAdidasMujer2 = new Product()
            {
                ProductId = new Guid("ef9069f0-638c-4291-a2b2-637d5b08fe77"),
                Name = "Top Adidas Essentials",
                Description = "Color negro para mujer.",
                Price = 65000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-1.png",
                ProductId = topAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-2.png",
                ProductId = topAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topAdidasMujer2, adidas, tops) + "-3.png",
                ProductId = topAdidasMujer2.ProductId
            });

            //Zapatillas
            var zapatillasAdidasHombre1 = new Product()
            {
                ProductId = new Guid("01591ef9-277b-4e32-bfd3-03226b4f5b33"),
                Name = "Zapatillas Fluidstreet Adidas",
                Description = "Color azul para hombre.",
                Price = 143000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasAdidasHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasHombre1.ProductId
            });

            var zapatillasAdidasHombre2 = new Product()
            {
                ProductId = new Guid("ff0b7b2c-abd2-4bae-9b81-43211a47b3ed"),
                Name = "Zapatillas Adidas Galaxy",
                Description = "Color azul y naranja para hombre.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasAdidasHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre2, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasHombre2.ProductId
            });

            var zapatillasAdidasMujer1 = new Product()
            {
                ProductId = new Guid("62fe85a1-3b51-46fa-9650-602b69f29fe9"),
                Name = "Zapatillas Adidas Runfalcon",
                Description = "Color aguamarina para mujer.",
                Price = 132000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasAdidasMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasMujer1.ProductId
            });

            var zapatillasAdidasMujer2 = new Product()
            {
                ProductId = new Guid("ec751372-dd49-41fd-baf7-7f51099d273a"),
                Name = "Zapatillas Adidas Ultimateshow",
                Description = "Color celeste para mujer.",
                Price = 156000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasAdidasMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasMujer2, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasMujer2.ProductId
            });

            var zapatillasAdidasNiñas1 = new Product()
            {
                ProductId = new Guid("1a20c0e5-a7be-4e83-b3d7-fb05cc54ca2e"),
                Name = "Zapatillas Adidas Altarun",
                Description = "Color rosa para niñas.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasAdidasNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiñas1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasNiñas1.ProductId
            });

            var zapatillasAdidasNiños1 = new Product()
            {
                ProductId = new Guid("862057bb-3275-43a5-98ee-9650f3f9c45f"),
                Name = "Zapatillas Adidas Altasport",
                Description = "Color blanco y azul para niños.",
                Price = 115000,
                Available = true,
                ReviewRate = 0,
                BrandId = adidas.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasAdidasNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-1.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-2.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasNiños1, adidas, zapatillas) + "-3.png",
                ProductId = zapatillasAdidasNiños1.ProductId
            });

            //Fila
            //Buzos y Camperas
            var buzoFilaHombre1 = new Product()
            {
                ProductId = new Guid("6761cc8a-5fd8-4b01-8b6a-944446f223e2"),
                Name = "Buzo Fila New Letter",
                Description = "Color negro para hombre.",
                Price = 142000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre1, fila, buzos) + "-1.png",
                ProductId = buzoFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre1, fila, buzos) + "-2.png",
                ProductId = buzoFilaHombre1.ProductId
            });

            var buzoFilaHombre2 = new Product()
            {
                ProductId = new Guid("8dbb6d66-dfc2-4144-9271-aeb099c030b4"),
                Name = "Buzo Fila Net",
                Description = "Color azul, blanco y rosa para hombre.",
                Price = 120500,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre2, fila, buzos) + "-1.png",
                ProductId = buzoFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaHombre2, fila, buzos) + "-2.png",
                ProductId = buzoFilaHombre2.ProductId
            });

            var buzoFilaMujer1 = new Product()
            {
                ProductId = new Guid("3d09411f-28af-4aee-bd2b-b0ad0630b25e"),
                Name = "Buzo Crop Fila",
                Description = "Buzo corto color rosa para mujer.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-1.png",
                ProductId = buzoFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-2.png",
                ProductId = buzoFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer1, fila, buzos) + "-3.png",
                ProductId = buzoFilaMujer1.ProductId
            });

            var buzoFilaMujer2 = new Product()
            {
                ProductId = new Guid("e5c695b3-2517-4163-92f9-fd76762a0a5f"),
                Name = "Buzo Fila Sweet",
                Description = "Color azul, blanco y rojo para mujer.",
                Price = 138000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer2, fila, buzos) + "-1.png",
                ProductId = buzoFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoFilaMujer2, fila, buzos) + "-2.png",
                ProductId = buzoFilaMujer2.ProductId
            });

            //Calzas
            var calzaFilaHombre1 = new Product()
            {
                ProductId = new Guid("a5a17788-615e-45f9-bcf8-4e31114caf27"),
                Name = "Calza Flex Fila",
                Description = "Color negro para hombre.",
                Price = 52000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(calzaFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaHombre1, fila, calzas) + "-1.png",
                ProductId = calzaFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaHombre1, fila, calzas) + "-2.png",
                ProductId = calzaFilaHombre1.ProductId
            });

            var calzaFilaMujer1 = new Product()
            {
                ProductId = new Guid("6d22ff2a-f7a9-4759-9c0b-2cf8a061842e"),
                Name = "Calza Fila Flat",
                Description = "Calza corta, color negro para mujer.",
                Price = 48000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-1.png",
                ProductId = calzaFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-2.png",
                ProductId = calzaFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer1, fila, calzas) + "-3.png",
                ProductId = calzaFilaMujer1.ProductId
            });

            var calzaFilaMujer2 = new Product()
            {
                ProductId = new Guid("e0b585b5-886a-483e-a75e-5d183b30b4af"),
                Name = "Calza Fila Tenis",
                Description = "Color gris para mujer.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-1.png",
                ProductId = calzaFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-2.png",
                ProductId = calzaFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaFilaMujer2, fila, calzas) + "-3.png",
                ProductId = calzaFilaMujer2.ProductId
            });

            //Remeras
            var remeraFilaHombre1 = new Product()
            {
                ProductId = new Guid("f1e7e785-d70a-4246-9b77-8253fb07e321"),
                Name = "Remera Australian Fila",
                Description = "Color celeste para hombre.",
                Price = 61000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-1.png",
                ProductId = remeraFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-2.png",
                ProductId = remeraFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre1, fila, remeras) + "-3.png",
                ProductId = remeraFilaHombre1.ProductId
            });

            var remeraFilaHombre2 = new Product()
            {
                ProductId = new Guid("838edd99-f13f-43a6-8cd6-afbddf440a89"),
                Name = "Remera G Fila",
                Description = "Color azul para hombre.",
                Price = 60500,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-1.png",
                ProductId = remeraFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-2.png",
                ProductId = remeraFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaHombre2, fila, remeras) + "-3.png",
                ProductId = remeraFilaHombre2.ProductId
            });

            var remeraFilaMujer1 = new Product()
            {
                ProductId = new Guid("6f655ea7-e257-481f-94a3-3ef7d8c4c46e"),
                Name = "Remera Fila Basic",
                Description = "Color negro para mujer.",
                Price = 48000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-1.png",
                ProductId = remeraFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-2.png",
                ProductId = remeraFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer1, fila, remeras) + "-3.png",
                ProductId = remeraFilaMujer1.ProductId
            });

            var remeraFilaMujer2 = new Product()
            {
                ProductId = new Guid("915ded0b-e311-4fa1-85fd-9546ba0983dd"),
                Name = "Remera Mindfull Fila",
                Description = "Remera manga larga, color negro para mujer.",
                Price = 57000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-1.png",
                ProductId = remeraFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-2.png",
                ProductId = remeraFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaMujer2, fila, remeras) + "-3.png",
                ProductId = remeraFilaMujer2.ProductId
            });

            var remeraFilaNiñas1 = new Product()
            {
                ProductId = new Guid("c191621c-6345-4b75-9fea-18fdfe9ad100"),
                Name = "Remera Vector Fila",
                Description = "Color lila para niñas.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraFilaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-1.png",
                ProductId = remeraFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-2.png",
                ProductId = remeraFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraFilaNiñas1, fila, remeras) + "-3.png",
                ProductId = remeraFilaNiñas1.ProductId
            });

            var remerafilaNiños1 = new Product()
            {
                ProductId = new Guid("acce2896-28b7-4995-a8e6-a5f800362499"),
                Name = "Remera Fila Basic",
                Description = "Color blanco para niños.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remerafilaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-1.png",
                ProductId = remerafilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-2.png",
                ProductId = remerafilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remerafilaNiños1, fila, remeras) + "-3.png",
                ProductId = remerafilaNiños1.ProductId
            });

            //Tops
            var topFilaMujer1 = new Product()
            {
                ProductId = new Guid("4c3b847d-2c63-44b9-9720-9d93744dadb2"),
                Name = "Top Fila Essentials",
                Description = "Color blanco para mujer.",
                Price = 81000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-1.png",
                ProductId = topFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-2.png",
                ProductId = topFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer1, fila, tops) + "-3.png",
                ProductId = topFilaMujer1.ProductId
            });

            var topFilaMujer2 = new Product()
            {
                ProductId = new Guid("918f7193-ccad-4ad5-b5f1-33e77588a77d"),
                Name = "Top Fila Essentials",
                Description = "Color gris para mujer.",
                Price = 87000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-1.png",
                ProductId = topFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-2.png",
                ProductId = topFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topFilaMujer2, fila, tops) + "-3.png",
                ProductId = topFilaMujer2.ProductId
            });

            //Zapatillas
            var zapatillasFilaHombre1 = new Product()
            {
                ProductId = new Guid("64ef8009-bdf3-4feb-a153-aaee4073c606"),
                Name = "Zapatillas Magnus Fila",
                Description = "Color azul, verde y blanco para hombre.",
                Price = 178000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasFilaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaHombre1.ProductId
            });

            var zapatillasFilaHombre2 = new Product()
            {
                ProductId = new Guid("7690ef50-3588-4ec1-a2d5-d7d2ccf6d40b"),
                Name = "Zapatillas Racer One Fila",
                Description = "Color negro y gris para hombre",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasFilaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaHombre2, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaHombre2.ProductId
            });

            var zapatillasFilaMujer1 = new Product()
            {
                ProductId = new Guid("abd609da-bfcf-4194-9c19-d61a3eab5fcb"),
                Name = "Zapatillas Fila Orbit",
                Description = "Color rosa para mujer.",
                Price = 174000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasFilaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaMujer1.ProductId
            });

            var zapatillasFilaMujer2 = new Product()
            {
                ProductId = new Guid("bba05e71-0cd0-48c7-bf1d-192707b77873"),
                Name = "Zapatillas Racer One Fila",
                Description = "Color beige y rosa para mujer.",
                Price = 158000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasFilaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaMujer2, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaMujer2.ProductId
            });

            var zapatillasFilaNiñas1 = new Product()
            {
                ProductId = new Guid("7617b910-b3e5-4d52-8041-3a3507cc052e"),
                Name = "Zapatillas Disruptor Fila",
                Description = "Color rosa para niñas.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasFilaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiñas1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaNiñas1.ProductId
            });

            var zapatillasFilaNiños1 = new Product()
            {
                ProductId = new Guid("bf86d111-a57e-44b0-b2e3-5195c73507a9"),
                Name = "Zapatillas Vulcan Fila",
                Description = "Color blanco, negro y rojo para niños.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = fila.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasFilaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-1.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-2.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasFilaNiños1, fila, zapatillas) + "-3.png",
                ProductId = zapatillasFilaNiños1.ProductId
            });

            //Nike
            //Buzos y Camperas
            var buzoNikeHombre1 = new Product()
            {
                ProductId = new Guid("bd73387d-9db3-4933-baab-7330ee1f741c"),
                Name = "Buzo Nike Sportwear",
                Description = "Color turquesa oscuro para hombre.",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-1.png",
                ProductId = buzoNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-2.png",
                ProductId = buzoNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeHombre1, nike, buzos) + "-3.png",
                ProductId = buzoNikeHombre1.ProductId
            });

            var buzoNikeMujer1 = new Product()
            {
                ProductId = new Guid("7ed42256-f685-44c0-a3c5-b0b2c07bee12"),
                Name = "Buzo Nike Flex",
                Description = "Color negro para mujer.",
                Price = 180000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-1.png",
                ProductId = buzoNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-2.png",
                ProductId = buzoNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer1, nike, buzos) + "-3.png",
                ProductId = buzoNikeMujer1.ProductId
            });

            var buzoNikeMujer2 = new Product()
            {
                ProductId = new Guid("087237c0-e590-44f5-806a-9ed8a5fdccc4"),
                Name = "Buzo Nike SportOn",
                Description = "Color negro para mujer.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-1.png",
                ProductId = buzoNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-2.png",
                ProductId = buzoNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeMujer2, nike, buzos) + "-3.png",
                ProductId = buzoNikeMujer2.ProductId
            });

            var buzoNikeNiñas1 = new Product()
            {
                ProductId = new Guid("4ee0914d-5aa7-4968-905f-7bd2750cb2e6"),
                Name = "Buzo Nike Mini",
                Description = "Color negro para niñas.",
                Price = 123000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-1.png",
                ProductId = buzoNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-2.png",
                ProductId = buzoNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiñas1, nike, buzos) + "-3.png",
                ProductId = buzoNikeNiñas1.ProductId
            });

            var buzoNikeNiños1 = new Product()
            {
                ProductId = new Guid("ee616c82-bc73-4316-9b30-ee25833805b3"),
                Name = "Campera Nike Mini",
                Description = "Color negro para niños.",
                Price = 125000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-1.png",
                ProductId = buzoNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-2.png",
                ProductId = buzoNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoNikeNiños1, nike, buzos) + "-3.png",
                ProductId = buzoNikeNiños1.ProductId
            });


            //Calzas
            var calzaNikeMujer1 = new Product()
            {
                ProductId = new Guid("19f7af3a-3576-4f83-a3b6-b1f51729d3f3"),
                Name = "Calza Nike Air",
                Description = "Color negro para mujer.",
                Price = 83000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-1.png",
                ProductId = calzaNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-2.png",
                ProductId = calzaNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer1, nike, calzas) + "-3.png",
                ProductId = calzaNikeMujer1.ProductId
            });

            var calzaNikeMujer2 = new Product()
            {
                ProductId = new Guid("671c59f3-0d7d-4e0b-81ae-c543368b605d"),
                Name = "Calza Nike Essentials",
                Description = "Calza corta, color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-1.png",
                ProductId = calzaNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-2.png",
                ProductId = calzaNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaNikeMujer2, nike, calzas) + "-3.png",
                ProductId = calzaNikeMujer2.ProductId
            });

            //Remeras
            var remeraNikeHombre1 = new Product()
            {
                ProductId = new Guid("8bd2ed90-bf07-4d3a-9bf1-24c46a3ceacc"),
                Name = "Remeras Nike SportOn",
                Description = "Color blanco para hombre.",
                Price = 68000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-1.png",
                ProductId = remeraNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-2.png",
                ProductId = remeraNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre1, nike, remeras) + "-3.png",
                ProductId = remeraNikeHombre1.ProductId
            });

            var remeraNikeHombre2 = new Product()
            {
                ProductId = new Guid("10c6cff5-d98c-48d6-85e1-175d7f7e5149"),
                Name = "Remera Nike Dry Fit",
                Description = "Remera manga larga, color negro para hombre.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraNikeHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-1.png",
                ProductId = remeraNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-2.png",
                ProductId = remeraNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeHombre2, nike, remeras) + "-3.png",
                ProductId = remeraNikeHombre2.ProductId
            });

            var remeraNikeMujer1 = new Product()
            {
                ProductId = new Guid("8b498a6e-dd85-4cf8-aa62-4a803a98d9a0"),
                Name = "Remera Nike Dry Fit",
                Description = "Color verde claro para mujer.",
                Price = 60500,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-1.png",
                ProductId = remeraNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-2.png",
                ProductId = remeraNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer1, nike, remeras) + "-3.png",
                ProductId = remeraNikeMujer1.ProductId
            });

            var remeraNikeMujer2 = new Product()
            {
                ProductId = new Guid("e4185b6c-15da-44f7-a48c-3520f3bb5354"),
                Name = "Remera Nike Miler",
                Description = "Color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-1.png",
                ProductId = remeraNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-2.png",
                ProductId = remeraNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeMujer2, nike, remeras) + "-3.png",
                ProductId = remeraNikeMujer2.ProductId
            });

            var remeraNikeNiñas1 = new Product()
            {
                ProductId = new Guid("9eacb903-4d21-49f3-bc4e-49b70a4387f3"),
                Name = "Remera Nike Sportswear",
                Description = "Color blanco para niñas.",
                Price = 44000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-1.png",
                ProductId = remeraNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-2.png",
                ProductId = remeraNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiñas1, nike, remeras) + "-3.png",
                ProductId = remeraNikeNiñas1.ProductId
            });

            var remeraNikeNiños1 = new Product()
            {
                ProductId = new Guid("08058bbb-9553-4a5e-84f7-7cb3ec5440dd"),
                Name = "Remera Nike Basic",
                Description = "Remera manga larga, color negro para niños.",
                Price = 44000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-1.png",
                ProductId = remeraNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-2.png",
                ProductId = remeraNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraNikeNiños1, nike, remeras) + "-3.png",
                ProductId = remeraNikeNiños1.ProductId
            });

            //Tops
            var topNikeMujer1 = new Product()
            {
                ProductId = new Guid("2c1b4bdb-2de7-43e2-a259-1fb75dc44fbc"),
                Name = "Top Nike Pro",
                Description = "Color negro para mujer.",
                Price = 81000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-1.png",
                ProductId = topNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-2.png",
                ProductId = topNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer1, nike, tops) + "-3.png",
                ProductId = topNikeMujer1.ProductId
            });

            var topNikeMujer2 = new Product()
            {
                ProductId = new Guid("c49d0933-ac5c-4e7a-8fb8-afe275fb59ff"),
                Name = "Top Nike Sportswear",
                Description = "Color beige para mujer.",
                Price = 82000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-1.png",
                ProductId = topNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-2.png",
                ProductId = topNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topNikeMujer2, nike, tops) + "-3.png",
                ProductId = topNikeMujer2.ProductId
            });

            //Zapatillas
            var zapatillasNikeHombre1 = new Product()
            {
                ProductId = new Guid("700fb128-5017-41ca-9221-765c3c3d9629"),
                Name = "Zapatillas Nike Flex",
                Description = "Color negro para hombre.",
                Price = 168000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasNikeHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeHombre1.ProductId
            });

            var zapatillasNikeHombre2 = new Product()
            {
                ProductId = new Guid("71ab1383-8f2f-4bf5-9619-c49703653021"),
                Name = "Zapatillas Nike Legend Essential",
                Description = "Color negro, azul y beige para hombre.",
                Price = 175000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasNikeHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeHombre2, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeHombre2.ProductId
            });

            var zapatillasNikeMujer1 = new Product()
            {
                ProductId = new Guid("54f52aed-e8e6-46f6-a363-1097b0b02e38"),
                Name = "Zapatillas Nike Air Pegasus",
                Description = "Color blanco y rosa para mujer.",
                Price = 160000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasNikeMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeMujer1.ProductId
            });

            var zapatillasNikeMujer2 = new Product()
            {
                ProductId = new Guid("5d6f08f0-fce2-4e2e-80e7-961619d48788"),
                Name = "Zapatillas Nike Trainer",
                Description = "Color negro, gris y lavanda para mujer.",
                Price = 185000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasNikeMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeMujer2, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeMujer2.ProductId
            });

            var zapatillasNikeNiñas1 = new Product()
            {
                ProductId = new Guid("e2db1b89-6662-4e1c-992a-500b485c505f"),
                Name = "Zapatillas Nike Pico",
                Description = "Color blanco y rosa para niñas.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasNikeNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiñas1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeNiñas1.ProductId
            });

            var zapatillasNikeNiños1 = new Product()
            {
                ProductId = new Guid("4c498b21-648d-443e-a7ac-5a7c61da8a83"),
                Name = "Zapatillas Nike Hustle",
                Description = "Color azul y negro para niños.",
                Price = 120000,
                Available = true,
                ReviewRate = 0,
                BrandId = nike.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasNikeNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-1.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-2.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasNikeNiños1, nike, zapatillas) + "-3.png",
                ProductId = zapatillasNikeNiños1.ProductId
            });

            //Puma
            //Buzos y Camperas
            var buzoPumaHombre1 = new Product()
            {
                ProductId = new Guid("67408bf6-6fa2-4a48-8b50-24552cfe88c1"),
                Name = "Buzo Puma Green",
                Description = "Color verde claro para hombre.",
                Price = 174000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-1.png",
                ProductId = buzoPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-2.png",
                ProductId = buzoPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre1, puma, buzos) + "-3.png",
                ProductId = buzoPumaHombre1.ProductId
            });

            var buzoPumaHombre2 = new Product()
            {
                ProductId = new Guid("b35995f9-43b3-49e9-8dfb-1aa1e154a2a9"),
                Name = "Buzo Puma Black",
                Description = "Color negro para hombre.",
                Price = 130000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-1.png",
                ProductId = buzoPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-2.png",
                ProductId = buzoPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaHombre2, puma, buzos) + "-3.png",
                ProductId = buzoPumaHombre2.ProductId
            });

            var buzoPumaMujer1 = new Product()
            {
                ProductId = new Guid("5cac55bf-6b5a-4c34-b9de-88681596b4bf"),
                Name = "Buzo Puma Black",
                Description = "Color negro para mujer.",
                Price = 160500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-1.png",
                ProductId = buzoPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-2.png",
                ProductId = buzoPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer1, puma, buzos) + "-3.png",
                ProductId = buzoPumaMujer1.ProductId
            });

            var buzoPumaMujer2 = new Product()
            {
                ProductId = new Guid("e67ce8dd-20c9-4205-b500-90fd166fed81"),
                Name = "Buzo Puma Mili",
                Description = "Color verde militar para mujer.",
                Price = 145000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-1.png",
                ProductId = buzoPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-2.png",
                ProductId = buzoPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaMujer2, puma, buzos) + "-3.png",
                ProductId = buzoPumaMujer2.ProductId
            });

            var buzoPumaNiñas1 = new Product()
            {
                ProductId = new Guid("b68432dd-7059-4885-a6ae-f5f323b62463"),
                Name = "Buzo Puma Mini",
                Description = "Color rosa para niñas.",
                Price = 110500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(buzoPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-1.png",
                ProductId = buzoPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-2.png",
                ProductId = buzoPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiñas1, puma, buzos) + "-3.png",
                ProductId = buzoPumaNiñas1.ProductId
            });

            var buzoPumaNiños1 = new Product()
            {
                ProductId = new Guid("474f92ee-95ac-4e69-900a-0ab296e3b296"),
                Name = "Buzo Puma Mini",
                Description = "Color negro y amarillo para niños.",
                Price = 110500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(buzoPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-1.png",
                ProductId = buzoPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-2.png",
                ProductId = buzoPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoPumaNiños1, puma, buzos) + "-3.png",
                ProductId = buzoPumaNiños1.ProductId
            });

            //Calzas
            var calzaPumaMujer1 = new Product()
            {
                ProductId = new Guid("b537ce4f-fafa-4a16-99ad-fecac1a17384"),
                Name = "Calza Puma Active",
                Description = "Color negro para mujer.",
                Price = 58000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer1, puma, calzas) + "-1.png",
                ProductId = calzaPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer1, puma, calzas) + "-2.png",
                ProductId = calzaPumaMujer1.ProductId
            });

            var calzaPumaMujer2 = new Product()
            {
                ProductId = new Guid("c617b2ad-3e1a-41ba-bbd7-567481a717b4"),
                Name = "Calza Puma Run",
                Description = "Color bordo y blanco para mujer.",
                Price = 55000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-1.png",
                ProductId = calzaPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-2.png",
                ProductId = calzaPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaPumaMujer2, puma, calzas) + "-3.png",
                ProductId = calzaPumaMujer2.ProductId
            });

            //Remeras
            var remeraPumaHombre1 = new Product()
            {
                ProductId = new Guid("aaa1ac0b-8147-4a79-b00a-f5489aeb1ffb"),
                Name = "Remera Puma Core",
                Description = "Color negro para hombre.",
                Price = 49000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-1.png",
                ProductId = remeraPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-2.png",
                ProductId = remeraPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre1, puma, remeras) + "-3.png",
                ProductId = remeraPumaHombre1.ProductId
            });

            var remeraPumaHombre2 = new Product()
            {
                ProductId = new Guid("a64d4099-646e-4691-9e48-76726984e83d"),
                Name = "Remera Puma Rudagon",
                Description = "Color negro para hombre.",
                Price = 53500,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-1.png",
                ProductId = remeraPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-2.png",
                ProductId = remeraPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaHombre2, puma, remeras) + "-3.png",
                ProductId = remeraPumaHombre2.ProductId
            });

            var remeraPumaMujer1 = new Product()
            {
                ProductId = new Guid("aa5ffbd0-841f-4954-abe7-b619a4b6a216"),
                Name = "Remera Puma Classics",
                Description = "Color blanco para mujer.",
                Price = 59000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-1.png",
                ProductId = remeraPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-2.png",
                ProductId = remeraPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer1, puma, remeras) + "-3.png",
                ProductId = remeraPumaMujer1.ProductId
            });

            var remeraPumaMujer2 = new Product()
            {
                ProductId = new Guid("0c92c422-5970-430e-a2b7-800313abf519"),
                Name = "Remera Puma Classics",
                Description = "Color negro para mujer.",
                Price = 57000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer2, puma, remeras) + "-1.png",
                ProductId = remeraPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaMujer2, puma, remeras) + "-2.png",
                ProductId = remeraPumaMujer2.ProductId
            });

            var remeraPumaNiñas1 = new Product()
            {
                ProductId = new Guid("bd54583c-534b-45b8-a8d2-ecfa27195c1d"),
                Name = "Remera Puma x Bob Esponja",
                Description = "Color amarillo para niñas.",
                Price = 45000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(remeraPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-1.png",
                ProductId = remeraPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-2.png",
                ProductId = remeraPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiñas1, puma, remeras) + "-3.png",
                ProductId = remeraPumaNiñas1.ProductId
            });

            var remeraPumaNiños1 = new Product()
            {
                ProductId = new Guid("f43ce520-c5bd-4cfc-a883-c2f66cc0e371"),
                Name = "Remera Puma x Bob Esponja",
                Description = "Color blanco para niños.",
                Price = 45000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(remeraPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-1.png",
                ProductId = remeraPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-2.png",
                ProductId = remeraPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraPumaNiños1, puma, remeras) + "-3.png",
                ProductId = remeraPumaNiños1.ProductId
            });

            //Tops
            var topPumaMujer1 = new Product()
            {
                ProductId = new Guid("26fbd842-584a-4a7a-ae3a-9cd26e637221"),
                Name = "Top Puma Keeps",
                Description = "Color negro para mujer.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-1.png",
                ProductId = topPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-2.png",
                ProductId = topPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer1, puma, tops) + "-3.png",
                ProductId = topPumaMujer1.ProductId
            });

            var topPumaMujer2 = new Product()
            {
                ProductId = new Guid("73387c1e-6507-4078-988d-30b2f91e8ca9"),
                Name = "Top Puma Mid Impact",
                Description = "Color negro para mujer.",
                Price = 76000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-1.png",
                ProductId = topPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-2.png",
                ProductId = topPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topPumaMujer2, puma, tops) + "-3.png",
                ProductId = topPumaMujer2.ProductId
            });

            //Zapatillas
            var zapatillasPumaHombre1 = new Product()
            {
                ProductId = new Guid("e108a5b9-d0d8-4d8e-a6d7-172404336125"),
                Name = "Zapatillas Puma Comet",
                Description = "Color rojo para hombre.",
                Price = 189000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasPumaHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaHombre1.ProductId
            });

            var zapatillasPumaHombre2 = new Product()
            {
                ProductId = new Guid("5deda8f6-2fd4-41fc-bdd2-3dec8330af3e"),
                Name = "Zapatillas Puma Taper",
                Description = "Color blanco y negro para hombre.",
                Price = 163000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasPumaHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaHombre2, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaHombre2.ProductId
            });

            var zapatillasPumaMujer1 = new Product()
            {
                ProductId = new Guid("4a94b629-2fbe-47dd-9a69-f487f1ef125b"),
                Name = "Zapatillas Puma Flyer Runner",
                Description = "Color lavanda para mujer.",
                Price = 178000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasPumaMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaMujer1.ProductId
            });

            var zapatillasPumaMujer2 = new Product()
            {
                ProductId = new Guid("1a8ec708-e252-4e9f-88eb-3b4b832ec350"),
                Name = "Zapatillas Puma Platinum",
                Description = "Color negro, blanco y beige para mujer.",
                Price = 165000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasPumaMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaMujer2, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaMujer2.ProductId
            });

            var zapatillasPumaNiñas1 = new Product()
            {
                ProductId = new Guid("f58b815e-12b1-4499-8f04-bb6725034853"),
                Name = "Zapatillas Puma Comet",
                Description = "Color rosa para niñas.",
                Price = 113000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasPumaNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiñas1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaNiñas1.ProductId
            });

            var zapatillasPumaNiños1 = new Product()
            {
                ProductId = new Guid("4adb6f3d-c138-43f6-b2fb-0ff0ec466381"),
                Name = "Zapatillas Puma Rebound",
                Description = "Color negro y blanco para niños.",
                Price = 113000,
                Available = true,
                ReviewRate = 0,
                BrandId = puma.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasPumaNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiños1, puma, zapatillas) + "-1.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasPumaNiños1, puma, zapatillas) + "-2.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasAdidasHombre1, puma, zapatillas) + "-3.png",
                ProductId = zapatillasPumaNiños1.ProductId
            });

            //Reebok
            //Buzos y Camperas
            var buzoReebokHombre1 = new Product()
            {
                ProductId = new Guid("029d34cc-06fd-44b7-a9f2-5270e754d788"),
                Name = "Buzo Reebok Sportswear",
                Description = "Color negro para hombre.",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-1.png",
                ProductId = buzoReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-2.png",
                ProductId = buzoReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre1, reebok, buzos) + "-3.png",
                ProductId = buzoReebokHombre1.ProductId
            });

            var buzoReebokHombre2 = new Product()
            {
                ProductId = new Guid("ed3d39e2-417d-43eb-99ad-864942355ca5"),
                Name = "Buzo Reebok VTM",
                Description = "Color azul para hombre.",
                Price = 173000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(buzoReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-1.png",
                ProductId = buzoReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-2.png",
                ProductId = buzoReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokHombre2, reebok, buzos) + "-3.png",
                ProductId = buzoReebokHombre2.ProductId
            });

            var buzoReebokMujer1 = new Product()
            {
                ProductId = new Guid("4cbb9373-c51f-43d5-a88b-82941daec0c1"),
                Name = "Buzo Reebok VTF",
                Description = "Color negro para mujer.",
                Price = 169000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer1, reebok, buzos) + "-1.png",
                ProductId = buzoReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer1, reebok, buzos) + "-2.png",
                ProductId = buzoReebokMujer1.ProductId
            });

            var buzoReebokMujer2 = new Product()
            {
                ProductId = new Guid("f94933b0-b851-41ec-85a6-62b172aad404"),
                Name = "Buzo Reebok Sportswear",
                Description = "Color negro para mujer.",
                Price = 140000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = buzos.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(buzoReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-1.png",
                ProductId = buzoReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-2.png",
                ProductId = buzoReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(buzoReebokMujer2, reebok, buzos) + "-3.png",
                ProductId = buzoReebokMujer2.ProductId
            });

            //Calzas
            var calzaReebokMujer1 = new Product()
            {
                ProductId = new Guid("01ebe9c3-d238-4dbc-81b0-0abe238878e2"),
                Name = "Calza Reebok Fit",
                Description = "Calza corta, color negro para mujer.",
                Price = 49500,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-1.png",
                ProductId = calzaReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-2.png",
                ProductId = calzaReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer1, reebok, calzas) + "-3.png",
                ProductId = calzaReebokMujer1.ProductId
            });

            var calzaReebokMujer2 = new Product()
            {
                ProductId = new Guid("c7160512-a504-4d24-bb65-e8357e591f89"),
                Name = "Calza Reebok Workout Ready",
                Description = "Color gris camo para mujer.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = calzas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(calzaReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-1.png",
                ProductId = calzaReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-2.png",
                ProductId = calzaReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(calzaReebokMujer2, reebok, calzas) + "-3.png",
                ProductId = calzaReebokMujer2.ProductId
            });

            //Remeras
            var remeraReebokHombre1 = new Product()
            {
                ProductId = new Guid("418f8acd-c640-40d6-8f1d-084465af5300"),
                Name = "Remera Reebok Graphic Series",
                Description = "Color negro para hombre.",
                Price = 64500,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-1.png",
                ProductId = remeraReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-2.png",
                ProductId = remeraReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre1, reebok, remeras) + "-3.png",
                ProductId = remeraReebokHombre1.ProductId
            });

            var remeraReebokHombre2 = new Product()
            {
                ProductId = new Guid("2cf5de04-2161-4f05-b978-31e332a827d8"),
                Name = "Remera Reebok Classic Soft",
                Description = "Color gris para hombre.",
                Price = 54000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(remeraReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-1.png",
                ProductId = remeraReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-2.png",
                ProductId = remeraReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokHombre2, reebok, remeras) + "-3.png",
                ProductId = remeraReebokHombre2.ProductId
            });

            var remeraReebokMujer1 = new Product()
            {
                ProductId = new Guid("7e76479a-8f23-4dda-aaaa-888a3d0797ea"),
                Name = "Remera Reebok Classic",
                Description = "Color celeste para mujer.",
                Price = 59000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-1.png",
                ProductId = remeraReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-2.png",
                ProductId = remeraReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer1, reebok, remeras) + "-3.png",
                ProductId = remeraReebokMujer1.ProductId
            });

            var remeraReebokMujer2 = new Product()
            {
                ProductId = new Guid("d72edb9a-9483-4cb6-a6ac-70044b28449d"),
                Name = "Remera Reebok Burnout",
                Description = "Color negro para mujer.",
                Price = 69000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = remeras.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(remeraReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-1.png",
                ProductId = remeraReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-2.png",
                ProductId = remeraReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(remeraReebokMujer2, reebok, remeras) + "-3.png",
                ProductId = remeraReebokMujer2.ProductId
            });

            //Tops
            var topReebokMujer1 = new Product()
            {
                ProductId = new Guid("991f1ffc-b151-421f-950a-8948d8e6cd86"),
                Name = "Top Reebok ColorFit",
                Description = "Color aguamarina para mujer.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-1.png",
                ProductId = topReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-2.png",
                ProductId = topReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer1, reebok, tops) + "-3.png",
                ProductId = topReebokMujer1.ProductId
            });

            var topReebokMujer2 = new Product()
            {
                ProductId = new Guid("f84976af-60b2-4dfa-8613-2139f7c681f8"),
                Name = "Top Reebok Flex",
                Description = "Color negro para mujer.",
                Price = 99000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = tops.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(topReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-1.png",
                ProductId = topReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-2.png",
                ProductId = topReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(topReebokMujer2, reebok, tops) + "-3.png",
                ProductId = topReebokMujer2.ProductId
            });

            //Zapatillas
            var zapatillasReebokHombre1 = new Product()
            {
                ProductId = new Guid("39e394fc-1afe-4969-8064-bc196834af14"),
                Name = "Zapatillas Reebok Flexagon",
                Description = "Color gris y blanco para hombre.",
                Price = 153000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasReebokHombre1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokHombre1.ProductId
            });

            var zapatillasReebokHombre2 = new Product()
            {
                ProductId = new Guid("e9b31ad4-5e25-42bf-9cc2-453814d552ee"),
                Name = "Zapatillas Reebok Forever",
                Description = "Color celeste y negro para hombre.",
                Price = 169000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Hombre,
            };
            products.Add(zapatillasReebokHombre2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokHombre2, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokHombre2.ProductId
            });

            var zapatillasReebokMujer1 = new Product()
            {
                ProductId = new Guid("2cba3f53-408e-4ed5-9b16-5c3a2ff10f70"),
                Name = "Zapatillas Reebok Liquifect",
                Description = "Color salmón para mujer.",
                Price = 193000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasReebokMujer1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokMujer1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokMujer1.ProductId
            });

            var zapatillasReebokMujer2 = new Product()
            {
                ProductId = new Guid("3660b93b-5430-421a-899d-adc6ac3514fd"),
                Name = "Zapatillas Reebok Lite Plus",
                Description = "Color azul y rosa para mujer.",
                Price = 142000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Mujer,
            };
            products.Add(zapatillasReebokMujer2);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokMujer2, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokMujer2.ProductId
            });

            var zapatillasReebokNiñas1 = new Product()
            {
                ProductId = new Guid("02f7e4b6-0ee0-4245-86c6-cdcdafec1bb5"),
                Name = "Zapatillas Reebok Classic Jogger",
                Description = "Color blanco y rosa para niñas.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niñas,
            };
            products.Add(zapatillasReebokNiñas1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiñas1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokNiñas1.ProductId
            });

            var zapatillasReebokNiños1 = new Product()
            {
                ProductId = new Guid("6b00b41e-a07c-4a7b-ba49-a01503ef6269"),
                Name = "Zapatillas Reebok Royal",
                Description = "Color azul, blanco y amarillo para niños.",
                Price = 105000,
                Available = true,
                ReviewRate = 0,
                BrandId = reebok.BrandId,
                CategoryId = zapatillas.CategoryId,
                Audience = Audience.Niños,
            };
            products.Add(zapatillasReebokNiños1);
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-1.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-2.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });
            pictureUrls.Add(new PictureUrl
            {
                Url = help.UrlConstructor(zapatillasReebokNiños1, reebok, zapatillas) + "-3.png",
                ProductId = zapatillasReebokNiños1.ProductId
            });


            modelBuilder.Entity<Product>().HasData(products.ToArray());
            modelBuilder.Entity<PictureUrl>().HasData(pictureUrls.ToArray());

        }
    }
}
