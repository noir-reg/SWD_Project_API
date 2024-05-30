using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("get-user-cart")] 
        public IActionResult GetUserCart([FromQuery] int userId)
        {
            return Ok(_cartService.GetCartByUserId(userId));
        }
        [HttpGet("remove-item-in-cart")]
        public IActionResult RemoveCartItem([FromQuery] int itemId)
        {   if(_cartService.RemoveCartItem(itemId))
            return Ok("Remove successfully");
        return BadRequest("Can not remove");
        }
        [HttpPost("create-cart")]
        public IActionResult CreateCart(List<CartItem> cart)
        {
            if (_cartService.CreateUserCart(cart).IsSuccess)
                return Ok(_cartService.CreateUserCart(cart));
            return BadRequest(_cartService.CreateUserCart(cart));
        }
        [HttpPost("update-cart")]
        public IActionResult UpdateCart(List<CartItemResponse> cart)
        {
            if (_cartService.UpdateUserCart(cart))
                return Ok("Update successfully");
            return BadRequest("Can not update");
        }
        [HttpGet("remove-cart")]
        public IActionResult RemoveCart([FromQuery]int userID)
        {
            if (_cartService.RemoveCartByUserId(userID))
                return Ok("Remove successfully");
            return BadRequest("Can not remove");
        }
    }
}
