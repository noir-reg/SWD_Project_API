using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Interface;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("get-all-products")]
        public ActionResult<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("get-product-by-id/{id}")]
        public ActionResult<IEnumerable<ProductResponse>> GetProductById(int id)
        {
            var products = _productService.GetProductById(id);
            if (products != null)
                return Ok(products);
            return NotFound("Product is not found");
        }
        [Authorize(Roles = "staff")]
        [HttpPost("create-product")]
        public IActionResult CreateProdcut(CreateProductRequest createProductRequest)
        {
            if (_productService.CreateProduct(createProductRequest))
                return Ok("Create product successfully");
            return BadRequest("Can not create product");
        }
        [Authorize(Roles = "staff")]
        [HttpPut("update-product")]
        public IActionResult UpdateProduct(UpdateProductRequest updateProductRequest)
        {

            if (_productService.UpdateProduct(updateProductRequest))
                return Ok("Update product successfully");
            return BadRequest("Can not update product");
        }
        [Authorize(Roles = "staff")]
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
        [HttpGet("filter-by-age/{age}")]
        public ActionResult<IEnumerable<ProductResponse>> FilterbyAge(int age)
        {
            var products = _productService.FilterbyAge(age);
            return Ok(products);
        }

        [HttpGet("filter-by-brand/{brand}")]
        public ActionResult<IEnumerable<ProductResponse>> FilterbyBrand(string brand)
        {
            var products = _productService.FilterbyBrand(brand);
            return Ok(products);
        }

        [HttpGet("filter-by-origin/{origin}")]
        public ActionResult<IEnumerable<ProductResponse>> FilterbyOrigin(string origin)
        {
            var products = _productService.FilterbyOrigin(origin);
            return Ok(products);
        }

        [HttpGet("filter-by-capacity/{capacity}")]
        public ActionResult<IEnumerable<ProductResponse>> FilterbyCapacity(int capacity)
        {
            var products = _productService.FilterbyCapacity(capacity);
            return Ok(products);
        }

        [HttpGet("filter-by-size/{size}")]
        public ActionResult<IEnumerable<ProductResponse>> FilterbySize(string size)
        {
            var products = _productService.FilterbySize(size);
            return Ok(products);
        }
        [HttpGet("gift-products")]
        public ActionResult<IEnumerable<ProductResponse>> IsGift()
        {
            var products = _productService.IsGift();
            return Ok(products);
        }
    }
}
