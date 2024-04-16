using API.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<CustomerBasket> CustomerBaskets { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            // FluentAPI
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Ejecuta todas las configuraciones de cada entidad
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Ejecutar el Seeding
            InitialSeeding.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //Todos los strings de la DB aplican ese MaxLength
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

    }
}
