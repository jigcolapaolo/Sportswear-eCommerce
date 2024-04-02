using API.Dtos;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext DbContext, IMapper mapper)
        {
            _dbContext = DbContext;
            _mapper = mapper;
        }

        //ApplicationDbContext dbContext2 = new ApplicationDbContext();   
       
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductToCreateDto productDto)
        {


            // Mapping
            Product product = _mapper.Map<Product>(productDto);

            // Add a product
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }




        //[HttpDelete]
        //public void DeleteProduct()
        //{

        //}



    }
}
