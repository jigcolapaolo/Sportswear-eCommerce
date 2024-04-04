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
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandController(ApplicationDbContext DbContext, IMapper mapper, IBrandRepository brandRepository)
        {
            //_dbContext = DbContext;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        //ApplicationDbContext dbContext2 = new ApplicationDbContext();   

        [HttpPost]
        public async Task<ActionResult> CreateBrand(BrandToCreateDto brandDto)
        {
            // Mapping
            Brand brand = _mapper.Map<Brand>(brandDto);

            // Add a brand
            //await _dbContext.Brands.AddAsync(brand);
            await _brandRepository.CreateBrandAsync(brand);

            //await _dbContext.SaveChangesAsync();
            await _brandRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}
