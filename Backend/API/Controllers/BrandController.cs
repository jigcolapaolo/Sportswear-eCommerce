﻿using API.Dtos;
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
        public async Task<ActionResult<BrandToReturnDto>> CreateBrand(BrandToCreateDto brandDto)
        {
            // Mapping
            Brand brand = _mapper.Map<Brand>(brandDto);

            // Add a brand
            await _brandRepository.CreateBrandAsync(brand);
            //Para que se guarde en la DB
            await _brandRepository.SaveChangesAsync();

            BrandToReturnDto brandToReturn = _mapper.Map<BrandToReturnDto>(brand);

            return NoContent();
        }

    }
}
