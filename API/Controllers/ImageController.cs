using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{productId}")]
        public ActionResult<IEnumerable<ImageResponse>> GetImageByProductId(int id)
        {
            var images = _imageService.GetImageByProductId(id);
            if (images == null || !images.Any())
                return NotFound("No images found for the specified product ID");

            return Ok(images);
        }

        [HttpPost("create")]
        public ActionResult CreateImage([FromBody] CreateImageRequest createImageRequest)
        {
            var result = _imageService.CreateImage(createImageRequest);
            if (!result)
                return BadRequest("Failed to create image");

            return Ok("Image created successfully");
        }

        [HttpPut("update")]
        public ActionResult UpdateImage( [FromBody] UpdateImageRequest updateImageRequest)
        {
            
            var result = _imageService.UpdateImage(updateImageRequest);
            if (!result)
                return BadRequest($"Failed to update image with ID ");

            return Ok($"Image with ID updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteImage(int id)
        {
            var result = _imageService.DeleteImage(id);
            if (!result)
                return BadRequest($"Failed to delete image with ID {id}");

            return Ok($"Image with ID {id} deleted successfully");
        }
    }
}