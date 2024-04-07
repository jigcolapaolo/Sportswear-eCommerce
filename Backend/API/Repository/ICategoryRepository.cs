﻿using API.Entities;

namespace API.Repository
{
    public interface ICategoryRepository
    {
        //Add
        Task CreateCategoryAsync(Category category);
        //Get
        Task<List<Category>> GetAllCategoriesAsync();

        Task SaveChangesAsync();
    }
}
