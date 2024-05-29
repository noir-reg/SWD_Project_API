using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public  OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("create")]
        public IActionResult CreateOrder(CreateOrderRequest createOrderRequest)
        {
            if (_orderService.CreateOrder(createOrderRequest) != null)
                return Ok(_orderService.CreateOrder(createOrderRequest));
            return BadRequest("Can not create order");
        }
        [HttpGet("get-orders-by-user-id")]
        public IActionResult GetOrdersById(int usersId,string? status)
        {            
                return Ok(_orderService.GetOrdersByUserId(usersId,status));            
        }
    }
}
