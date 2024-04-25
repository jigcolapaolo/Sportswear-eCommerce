using API.Dtos;
using API.Dtos.Account;
using API.Entities;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/basket")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public BasketItemController(IBasketItemRepository basketItemRepository, IMapper mapper, IProductRepository productRepository)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        // Get, Post, Delete.
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketItem(Guid id)
        {
            var customerBasket = await _basketItemRepository.GetBasketItemAsync(id);

            if (customerBasket == null)
            {
                return NotFound("Id Invalido!");
            }            
            
            return Ok(customerBasket);
            
        }
        
        [HttpPost]
        public async Task<ActionResult<CustomerBasketToReturnDto>> CreateBasketItemAsync(CustomerBasketToCreateDto basketToCreateDto)
        {
            foreach (var item in basketToCreateDto.BasketItems)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);

                if (product == null)
                {
                    return NotFound("ProductId no existe!");
                }
            }


            CustomerBasket customerBasket =_mapper.Map<CustomerBasket>(basketToCreateDto);

            var basketCreated = await _basketItemRepository.CreateBasketItemAsync(customerBasket);

            var customerBasketToReturnDto = _mapper.Map<CustomerBasketToReturnDto>(basketCreated);

            return Ok(customerBasketToReturnDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketItem(Guid id)
        {
            try
            {
                await _basketItemRepository.DeleteBasketItemAsync(id);
                return Ok("El elemento fue eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el elemento de la cesta: {ex.Message}");
            }
        }
    }
}
