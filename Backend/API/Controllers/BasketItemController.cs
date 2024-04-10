using API.Dtos;
using API.Entities;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Route("api/basket")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public BasketItemController(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        // Get, Post, Delete.
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBasketItem(Guid id)
        {
            var getSuccessfully = await _basketItemRepository.GetBasketItemAsync(id);

            if (getSuccessfully == null)
            {
                return NotFound("No se puede encontrar el elemento en la cesta");
            }
            else
            {
                return Ok("Item Encontrado");
            }
        }
        
        [HttpPost]
        public async Task CreateBasketItemAsync(BasketItem basketItem)
        {
            await _basketItemRepository.CreateBasketItemAsync(basketItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasketItem(Guid id)
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
