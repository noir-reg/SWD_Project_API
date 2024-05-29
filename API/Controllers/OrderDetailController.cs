using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/order-details")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpPost("create")]
        public IActionResult CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest)
        {
           if( _orderDetailService.CreateOrderDetail(createOrderDetailRequest))
                return Ok("Create order detail successfully");
            return BadRequest("Can not create order detail");
        }
    }
}
