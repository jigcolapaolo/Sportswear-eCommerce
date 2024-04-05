﻿using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IBrandRepository
    {   
        // Create a new brand
        Task CreateBrandAsync(Brand brand);

        // Saves changes into the database
        Task SaveChangesAsync();

    }
}
