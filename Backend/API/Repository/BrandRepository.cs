using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task CreateBrandAsync(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);

        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
