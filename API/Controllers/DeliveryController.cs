using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/deliveries")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [Authorize(Roles = "staff")]
        [HttpPost("assign-delivery")]
        public IActionResult CreateDelivery([FromQuery] int orderId, [FromQuery] int deliveryManId)
        {
            var result = _deliveryService.CreateDelivery(orderId, deliveryManId);
            if (result)
                return Ok("Assign successfully");
            return BadRequest();
        }
        [Authorize(Roles = "staff")]
        [HttpPost("unassign-delivery")]
        public IActionResult DeleteDelivery([FromQuery] int deliveryId)
        {
            var result = _deliveryService.DeleteDelivery(deliveryId);
            if (result)
                return Ok("Unassign successfully");
            return BadRequest();
        }

        [HttpGet("get-deliveries-by-delivery-man-id")]
        public IActionResult GetDeliveryById([FromQuery] int deliveryManId)
        {
            var result = _deliveryService.GetDeliveryOrdersByDeliveryManId(deliveryManId);
            if (result.Any())
                return Ok(result);
            return NotFound();
        }
        [HttpGet("get-delivered-orders-by-delivery-man-id")]
        public IActionResult GetDeliveredById([FromQuery] int deliveryManId)
        {
            var result = _deliveryService.GetDeliveredOrdersByDeliveryManId(deliveryManId);
            if (result.Any())
                return Ok(result);
            return NotFound();
        }
        [Authorize(Roles = "staff")]
        [HttpGet("get-all-deliveries")]
        public IActionResult GetDelivery()
        {
            var result = _deliveryService.GetAllDeliveryOrders();
            if (result.Any())
                return Ok(result);
            return NotFound();
        }
    }
}
