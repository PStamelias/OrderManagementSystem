using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            await _orderService.CreateOrder(orderDTO);
            //dummy comment
            
            return Ok();
        }

        [HttpGet]
        [Route("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order  = await _orderService.GetOrderById(id);
            //dummy comment
            return Ok(order);
        }

    }
}
