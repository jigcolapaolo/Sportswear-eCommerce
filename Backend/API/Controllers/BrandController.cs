using API.Dtos;
using API.Entities;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandController(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        } 

        [HttpPost]
        public async Task<ActionResult> CreateBrand(BrandToCreateDto brandDto)
        {
            // Mapping
            Brand brand = _mapper.Map<Brand>(brandDto);

            await _brandRepository.CreateBrandAsync(brand);
            await _brandRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("allBrands")]
        public async Task<ActionResult<List<BrandToReturnDto>>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();

            if (brands == null || brands.Count == 0)
            {
                return NotFound("No se han encontrado Marcas.");
            }

            return _mapper.Map<List<BrandToReturnDto>>(brands);
        }

    }
}
