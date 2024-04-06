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
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryToReturnDto>> CreateCategory(CategoryToCreateDto categoryDto)
        {
            // Mapping
            Category category = _mapper.Map<Category>(categoryDto);

            // Add a product
            await _categoryRepository.CreateCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();

            CategoryToReturnDto categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);

            return NoContent();
        }
    }
}
