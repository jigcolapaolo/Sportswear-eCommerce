using API.Entities;
using API.Services;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ApplicationDbContext DbContext, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryToCreateDto categoryDto)
        {
            // Mapping
            Category category = _mapper.Map<Category>(categoryDto);

            // Add a product
            await _categoryRepository.CreateCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
