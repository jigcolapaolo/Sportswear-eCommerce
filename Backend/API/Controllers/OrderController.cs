using API.Dtos;
using API.Entities;
using API.Migrations;
using API.Repository;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(IMapper mapper, IOrdersRepository ordersRepository)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderToCreateDto orderDto, Guid basketId)
        {
            // Mapping
            Orders order = _mapper.Map<Orders>(orderDto);

            await _ordersRepository.CreateOrdersAsync(order);
            await _ordersRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderToReturnDto>>> GetAllOrders()
        {
            var orders = await _ordersRepository.GetAllOrdersAsync();

            if (orders == null || orders.Count == 0)
            {
                return NotFound("No se han encontrado ordenes.");
            }

            return _mapper.Map<List<OrderToReturnDto>>(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid orderId)
        {
            var order = await _ordersRepository.GetOrdersByIdAsync(orderId);

            if (order == null)
            {
                return NotFound("Orden no encontrada.");
            }

            var orderToReturn = _mapper.Map<OrderToReturnDto>(order);

            return orderToReturn;
        }
    }
}
