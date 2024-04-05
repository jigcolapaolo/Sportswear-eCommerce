using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }



        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            // FluentAPI
        }

       
    }
}
