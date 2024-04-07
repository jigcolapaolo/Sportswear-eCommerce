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
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
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


            return Ok("Producto agregado exitosamente.");
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();

            if(products == null || products.Count == 0)
            {
                return NotFound("No se ha encontrado ningún producto.");
            }

            return _mapper.Map<List<ProductToReturnDto>>(products);
        }

        [HttpGet("byName/{productName}")]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProductsByName(string productName)
        {
            var products = await _productRepository.GetProductsByNameAsync(productName);

            if (products == null || products.Count == 0)
            {
                return NotFound("No se ha encontrado ningún producto.");
            }

            var productsToReturn = _mapper.Map<List<ProductToReturnDto>>(products);

            return productsToReturn;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(Guid productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
            {
                return NotFound("Producto no encontrado.");
            }

            var productToReturn = _mapper.Map<ProductToReturnDto>(product);

            return productToReturn;
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            var success = await _productRepository.DeleteProductAsync(productId);

            if (!success)
            {
                return NotFound("Error al eliminar el producto, no se encontró.");
            }

            return Ok("Producto eliminado exitosamente.");
        }


        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(Guid productId, ProductToUpdateDto productDto, Guid brandId, Guid categoryId)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productId);

            if (existingProduct == null)
            {
                return NotFound("Producto no encontrado");
            }

            _mapper.Map(productDto, existingProduct);
            existingProduct.BrandId = brandId;
            existingProduct.CategoryId = categoryId;


            var success = await _productRepository.UpdateProductAsync(existingProduct);

            if (!success)
            {
                return StatusCode(500);
            }

            return Ok("Producto actualizado exitosamente.");
        }










    }
}
