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
            var hasDuplicate = await _categoryRepository.HasDuplicateName(categoryDto.Name);

            if (hasDuplicate)
            {
                return BadRequest("Ya existe una Categoría con ese nombre.");
            }


            // Mapping
            Category category = _mapper.Map<Category>(categoryDto);

            // Add a product
            await _categoryRepository.CreateCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();

            CategoryToReturnDto categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryToReturnDto>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            if(categories == null || categories.Count == 0)
            {
                return NotFound("No se han encontrado Categorías. ");
            }

            return _mapper.Map<List<CategoryToReturnDto>>(categories);
        }
    }
}
