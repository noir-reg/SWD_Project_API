using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;   
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
       
        [HttpPost("create-products")]
        public IActionResult CreateProdcut(CreateProductRequest createProductRequest)
        {
            if (_productService.CreateProduct(createProductRequest))
                return Ok("Create product successfully");
            return BadRequest("Can not create product");
        }
        [HttpPost("update-account")]
        public IActionResult UpdateProduct(UpdateProductRequest updateProductRequest)
        {

            if (_productService.UpdateProduct(updateProductRequest))
                return Ok("Update product successfully");
            return BadRequest("Can not update product");
        }
        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (_productService.DeleteProduct(id))
                return Ok("Delete product successfully");
            return BadRequest("Cannot delete product");
        }
        [HttpGet("search-products")]
        public IActionResult SearchProducts(string keyword)
        {
            var products = _productService.SearchProducts(keyword);
            if (products.Any())
                return Ok(products);
            return NotFound("No products found");
        }
        [HttpGet("top-selling")]
        public IActionResult GetTopSellingProducts([FromQuery] int topN)
        {
            var products = _productService.GetProductsByQuantitySold(topN);
            if (products.Any())
            {
                return Ok(products);
            }
            return NotFound("No products found");
        }
        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = _productService.GetProductsByCategory(categoryId);
            if (products.Any())
            {
                return Ok(products);
            }
            return NotFound("No products found for the specified category");
        }
    }
}
