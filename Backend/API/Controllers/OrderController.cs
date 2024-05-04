using API.configurations;
using API.Dtos;
using API.Entities;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository ordersRepository, IBasketItemRepository basketItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _basketItemRepository = basketItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(Guid basketId)
        {   
            // get basket
            var basket = await _basketItemRepository.GetBasketItemAsync(basketId);

            // create a list of items
            var items = new List<OrderItem>();
            foreach (var item in basket.BasketItems)
            {
                // get the product
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                // create ab orderItem
                var orderItem = new OrderItem(item.Price, item.Quantity,product.ProductId);

                items.Add(orderItem);
            }

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // get the email
            var email = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            // create order
            var order = new Order(items, email, subtotal);

            // save to db
            await _ordersRepository.CreateOrdersAsync(order);

            // delete basket
            await _basketItemRepository.DeleteBasketItemAsync(basketId);

            var orderDto =  _mapper.Map<OrderToReturnDto>(order);

            return Ok(orderDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdForUser(Guid id)
        {

            var order = await _ordersRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound(); // Devuelve 404 si la orden no se encuentra
            }

            return Ok(_mapper.Map<OrderToReturnDto>(order)); // Devuelve la orden encontrada con el código de estado 200
        }

    }
}
