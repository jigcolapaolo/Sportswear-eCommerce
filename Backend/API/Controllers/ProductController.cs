using API.Dtos;
using API.Entities;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult> CreateProduct(ProductToCreateDto productDto, [Required] Guid brandId, [Required] Guid categoryId, [Required] int audienceId)
        {

            //AutoMapper aplica proyeccion para convertir List<string> -> List<PictureUrl>
            Product product = _mapper.Map<Product>(productDto);
            product.BrandId = brandId;
            product.CategoryId = categoryId;
            product.Description = string.IsNullOrEmpty(product.Description) ? "-Sin Descripción-" : product.Description;

            if (string.IsNullOrEmpty(product.Name))
                return BadRequest("El producto debe tener un nombre.");

            //Validación Audience
            int maxEnumLength = Enum.GetValues(typeof(Audience)).Length;
            if (audienceId >= 0 && audienceId < maxEnumLength)
                product.Audience = (Audience)audienceId;
            else
                return BadRequest("AudienceId debe estar entre 0 y " + (maxEnumLength - 1));

            //Por cada string ingresado en List<string>, creo nuevas imagenes relacionadas con este objeto
            List<PictureUrl> pictureUrls = productDto.PictureUrls.Select(url => new PictureUrl { Url = url }).ToList();
            product.PictureUrls = pictureUrls;


            //Add a product
            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();


            return Ok("Producto agregado exitosamente.");
        }

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
                return NotFound("Producto no encontrado.");

            var productToReturn = _mapper.Map<ProductToReturnDto>(product);

            return productToReturn;
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteProduct(Guid id)
        //{
        //    var success = await _productRepository.DeleteProductAsync(id);

        //    if (!success)
        //        return NotFound("Error al eliminar el producto, no se encontró.");

        //    return Ok("Producto eliminado exitosamente.");
        //}


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromQuery] ProductToUpdateDto productDto)
        {
            //Validación de AudienceId ingresado.
            int enumMaxLength = Enum.GetValues(typeof(Audience)).Length - 1;
            if (productDto.AudienceId != null && !(productDto.AudienceId >= 0 && productDto.AudienceId <= enumMaxLength))
                return BadRequest("Solo AudienceIDs de 0 a " + enumMaxLength + " inclusive.");

            var success = await _productRepository.UpdateProductAsync(id, productDto);

            if (!success)
                return BadRequest("Producto no encontrado.");

            return Ok("Producto actualizado exitosamente.");
        }

    }
}
