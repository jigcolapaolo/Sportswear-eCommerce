using API.Dtos;
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

        //[HttpGet]
        //public async Task<ActionResult<List<ProductToReturnDto>>> GetAllProducts(
        //    [FromQuery] string? name = null,
        //    [FromQuery] string? brandName = null,
        //    [FromQuery] string? categoryName = null,
        //    [FromQuery] bool? available = null,
        //    [FromQuery] bool? cheaperFirst = null,
        //    [FromQuery] bool? alphabeticalOrder = null)
        //{
        //    var products = await _productRepository.GetAllProductsAsync();

        //    //Filtros
        //    if (!string.IsNullOrEmpty(name))
        //        products = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

        //    if (!string.IsNullOrEmpty(brandName))
        //        products = products.Where(p => p.Brand.Name.ToLower().Contains(brandName.ToLower())).ToList();

        //    if (!string.IsNullOrEmpty(categoryName))
        //        products = products.Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower())).ToList();

        //    if(available != null)
        //        products = products.Where(p => p.Available == available).ToList();

        //    //Orden
        //    //Precio
        //    if (cheaperFirst.HasValue)
        //    {
        //        if (cheaperFirst.Value)
        //            products = products.OrderBy(p => p.Price).ToList();
        //        else
        //            products = products.OrderByDescending(p => p.Price).ToList();
        //    }

        //    //Nombre
        //    if (alphabeticalOrder.HasValue)
        //    {
        //        if (alphabeticalOrder.Value)
        //            products = products.OrderBy(p => p.Name).ToList();
        //        else
        //            products = products.OrderByDescending(p => p.Name).ToList();
        //    }



        //    if (products == null || products.Count == 0)
        //        return NotFound("No se ha encontrado ningún producto.");


        //    return _mapper.Map<List<ProductToReturnDto>>(products);
        //}

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAllProducts(
            [FromQuery] string? name = null,
            [FromQuery] string? brandName = null,
            [FromQuery] string? categoryName = null,
            [FromQuery] bool? available = null,
            [FromQuery] bool? cheaperFirst = null,
            [FromQuery] bool? alphabeticalOrder = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var products = await _productRepository.GetAllProductsAsync();

            //Filtros
            if (!string.IsNullOrEmpty(name))
                products = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

            if (!string.IsNullOrEmpty(brandName))
                products = products.Where(p => p.Brand.Name.ToLower().Contains(brandName.ToLower())).ToList();

            if (!string.IsNullOrEmpty(categoryName))
                products = products.Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower())).ToList();

            if (available != null)
                products = products.Where(p => p.Available == available).ToList();

            //Orden
            //Precio
            if (cheaperFirst.HasValue)
            {
                if (cheaperFirst.Value)
                    products = products.OrderBy(p => p.Price).ToList();
                else
                    products = products.OrderByDescending(p => p.Price).ToList();
            }

            //Nombre
            if (alphabeticalOrder.HasValue)
            {
                if (alphabeticalOrder.Value)
                    products = products.OrderBy(p => p.Name).ToList();
                else
                    products = products.OrderByDescending(p => p.Name).ToList();
            }


            if (products == null || products.Count == 0)
                return NotFound("No se ha encontrado ningún producto.");


            //Paginación
            var totalItems = products.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var itemsToShow = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = _mapper.Map<List<ProductToReturnDto>>(itemsToShow)
            };

            return Ok(response);
        }




        //[HttpGet("byName/{productName}")]
        //public async Task<ActionResult<List<ProductToReturnDto>>> GetProductsByName(string productName)
        //{
        //    var products = await _productRepository.GetProductsByNameAsync(productName);

        //    if (products == null || products.Count == 0)
        //    {
        //        return NotFound("No se ha encontrado ningún producto.");
        //    }

        //    var productsToReturn = _mapper.Map<List<ProductToReturnDto>>(products);

        //    return productsToReturn;
        //}

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
