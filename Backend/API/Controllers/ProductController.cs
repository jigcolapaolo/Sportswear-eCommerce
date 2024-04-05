﻿using API.Dtos;
using API.Entities;
using API.Repository;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductController(ApplicationDbContext DbContext, IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductToCreateDto productDto)
        {

            // Mapping
            Product product = _mapper.Map<Product>(productDto);

            // Add a product
            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return NoContent();
        }




        //[HttpDelete]
        //public void DeleteProduct()
        //{

        //}



    }
}
