using API.Dtos;
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

        public ProductController(ApplicationDbContext DbContext, IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductToCreateDto productDto, Guid brandId, Guid categoryId)
        {

            // Mapping
            Product product = _mapper.Map<Product>(productDto);
            product.BrandId = brandId;
            product.CategoryId = categoryId;

            // Add a product
            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();


            return NoContent();
        }

        [HttpGet("byname/{productName}")]
        public async Task<ActionResult<List<ProductToGetDto>>> GetProductsByName(string productName)
        {
            var products = await _productRepository.GetProductsByNameAsync(productName);

            if (products == null || products.Count == 0)
            {
                return NotFound("Producto no encontrado.");
            }

            var productsToReturn = _mapper.Map<List<ProductToGetDto>>(products);

            return productsToReturn;
        }









    }
}
