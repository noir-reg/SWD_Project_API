using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{

    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound("Category not found");
        }
        [HttpGet("get-all-categories")]
        public ActionResult<IEnumerable<CategoryResponse>> GetAllCategory()
        {
            var categories = _categoryService.GetAllCategory();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found");
            }
            return Ok(categories);
        }

        [Authorize(Roles = "staff")]
        [HttpPost("create-category")]
        public IActionResult CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            if (_categoryService.CreateCategory(createCategoryRequest))
            {
                return Ok("Category created successfully");
            }
            return BadRequest("Unable to create category");
        }
        [Authorize(Roles = "staff")]
        [HttpPut("update-category")]
        public IActionResult UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            if (_categoryService.UpdateCategory(updateCategoryRequest))
            {
                return Ok("Category updated successfully");
            }
            return NotFound("Category not found");
        }
        [Authorize(Roles = "staff")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (_categoryService.DeleteCategory(id))
            {
                return Ok("Category deleted successfully");
            }
            return NotFound("Category not found");
        }
    }
}

