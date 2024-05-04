using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Entities.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Data Seed
            //var cienciaFiccion = new Genero { Id = 5, Nombre = "Ciencia Ficción" };
            //var animacion = new Genero { Id = 6, Nombre = "Animación" };
            //builder.HasData(cienciaFiccion, animacion);

        }
    }
}
