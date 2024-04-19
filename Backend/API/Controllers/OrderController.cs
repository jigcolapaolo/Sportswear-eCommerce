using API.configurations;
using API.Dtos;
using API.Entities;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderToCreateDTO orderDTO)
        {
            var order = new Order
            {
                OrderDate = orderDTO.OrderDate,
                Email = orderDTO.Email,
                Subtotal = orderDTO.Subtotal,
                Status = orderDTO.Status,
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDTO in orderDTO.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = itemDTO.ProductId,
                    Price = itemDTO.Price,
                    Quantity = itemDTO.Quantity
                };

                order.OrderItems.Add(orderItem);
            }

            await _ordersRepository.CreateOrdersAsync(order);

            var options = JsonSerializerOptionsConfig.GetJsonSerializerOptions(); // Obtener opciones de serialización JSON
            string jsonString = JsonSerializer.Serialize(order, options); // Serializar objeto order con las opciones de serialización

            // Devuelve la respuesta HTTP con el objeto order serializado como JSON
            return Content(jsonString, "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _ordersRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _ordersRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound(); // Devuelve 404 si la orden no se encuentra
            }

            return Ok(order); // Devuelve la orden encontrada con el código de estado 200
        }

    }
}
