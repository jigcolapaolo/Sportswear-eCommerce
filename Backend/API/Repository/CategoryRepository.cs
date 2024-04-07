using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Add
        public async Task CreateCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
        }
        //Get
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
