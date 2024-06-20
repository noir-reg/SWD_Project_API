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
        public IActionResult GetOrdersById([FromQuery]int usersId, [FromQuery] string? status)
        {            
                return Ok(_orderService.GetOrdersByUserId(usersId,status));
        }
        [HttpGet("get-orders")]
        public IActionResult GetOrders([FromQuery] string? status)
        {
            return Ok(_orderService.GetOrders(status));
        }
        [HttpGet("get-order-by-id")]
        public IActionResult GetOrdersById([FromQuery] int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }
        [HttpGet("update-order-status")]
        public IActionResult UpdateOrderStatus([FromQuery] int orderId, [FromQuery] int? staffId, [FromQuery] string status)
        {
            if (_orderService.UpdateOrderStatus(orderId, staffId, status))
                return Ok("Update order status successfully");
            return BadRequest("Can not update order status");
        }
        [HttpGet("confirm-delivered-order")]
        public IActionResult ConfirmOrder([FromQuery] int orderId)
        {
            if (_orderService.ConfirmOrder(orderId))
                return Ok("Confirm order successfully");
            return BadRequest("Can not confirm order");
        }
    }
}
