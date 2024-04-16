using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IBrandRepository
    {   
        //Add
        Task CreateBrandAsync(Brand brand);
        //Get
        Task<List<Brand>> GetAllBrandsAsync();
        Task<bool> HasDuplicateName(string name);

        // Saves changes into the database
        Task SaveChangesAsync();

    }
}
