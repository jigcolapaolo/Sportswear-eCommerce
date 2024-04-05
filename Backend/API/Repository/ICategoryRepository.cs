using API.Entities;

namespace API.Repository
{
    public interface ICategoryRepository
    {
        //New Category
        Task CreateCategoryAsync(Category category);

        // Saves changes into the database
        Task SaveChangesAsync();
    }
}
