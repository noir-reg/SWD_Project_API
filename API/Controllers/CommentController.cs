using Microsoft.AspNetCore.Mvc;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("get-comments")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetComments()
        {
            var comments = await _commentService.GetCommentsAsync();
            if (!comments.Any())
            {
                return NotFound("No comments available.");
            }
            return Ok(comments); 
        }

        [HttpGet("get-comments-by-product-id/{productID}")]
        public async Task<ActionResult<Response<IEnumerable<CommentDTO>>>> GetCommentsByProductID(int productID)
        {
            var comments = await _commentService.GetCommentsByProductIDAsync(productID);
            if (!comments.Any())
            {
                return Ok(new Response<IEnumerable<CommentDTO>> { Notification = $"No comments found for product with id {productID}." });
            }
            return Ok(new Response<IEnumerable<CommentDTO>> { Data = comments });
        }

        [HttpPost("create-comment")]
        public async Task<ActionResult<CommentDTO>> CreateComment(CreateCommentDTO createCommentDTO)
        {
            var commentDTO = new CommentDTO();
            commentDTO.UserId = createCommentDTO.UserId;
            commentDTO.ProductId = createCommentDTO.ProductId;
            commentDTO.Content = createCommentDTO.Content;
            commentDTO.Rate = createCommentDTO.Rate;
            commentDTO.Status = createCommentDTO.Status;
            var comment = await _commentService.CreateCommentAsync(commentDTO);
            return CreatedAtAction(nameof(GetComments), new { id = comment.Id }, comment);
        }

        [HttpPatch("toggle-comment-status/{id}")]
        public async Task<ActionResult> ToggleCommentStatus(int id, [FromBody] bool status)
        {
            await _commentService.ToggleCommentStatusAsync(id, status);
            return NoContent();
        }

        [HttpDelete("delete-comment")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
