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
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }



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

    }
}
