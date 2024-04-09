﻿using API.Dtos;
using API.Entities;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateProduct(ProductToCreateDto productDto, Guid brandId, Guid categoryId)
        //{

        //    // Mapping
        //    Product product = _mapper.Map<Product>(productDto);
        //    product.BrandId = brandId;
        //    product.CategoryId = categoryId;

        //    // Add a product
        //    await _productRepository.CreateProductAsync(product);
        //    await _productRepository.SaveChangesAsync();


        //    return Ok("Producto agregado exitosamente.");
        //}

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProductsList([FromQuery] ProductFilterDto filterDto)
        {
            var products = await _productRepository.GetProductsListAsync(filterDto);


            if (products == null || products.Count == 0)
                return NotFound("No se ha encontrado ningún producto.");


            //Paginación
            var totalItems = products.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / filterDto.PageSize);
            var itemsToShow = products.Skip((filterDto.PageNumber - 1) * filterDto.PageSize).Take(filterDto.PageSize).ToList();


            return _mapper.Map<List<ProductToReturnDto>>(itemsToShow);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Producto no encontrado.");
            }

            var productToReturn = _mapper.Map<ProductToReturnDto>(product);

            return productToReturn;
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteProduct(Guid id)
        //{
        //    var success = await _productRepository.DeleteProductAsync(id);

        //    if (!success)
        //    {
        //        return NotFound("Error al eliminar el producto, no se encontró.");
        //    }

        //    return Ok("Producto eliminado exitosamente.");
        //}


        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateProduct(Guid id, ProductToUpdateDto productDto, Guid brandId, Guid categoryId)
        //{
        //    var existingProduct = await _productRepository.GetProductByIdAsync(id);

        //    if (existingProduct == null)
        //    {
        //        return NotFound("Producto no encontrado");
        //    }

        //    _mapper.Map(productDto, existingProduct);
        //    existingProduct.BrandId = brandId;
        //    existingProduct.CategoryId = categoryId;


        //    var success = await _productRepository.UpdateProductAsync(existingProduct);

        //    if (!success)
        //    {
        //        return StatusCode(500);
        //    }

        //    return Ok("Producto actualizado exitosamente.");
        //}

    }
}
