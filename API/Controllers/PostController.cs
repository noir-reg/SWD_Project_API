using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Interface;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers

{

    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("get-all-posts")]
        public ActionResult<IEnumerable<ProductResponse>> GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }
        [HttpGet("get-post-by-id/{id}")]
        public ActionResult<IEnumerable<PostResponse>> GetPostByID(int id)
        {
            var posts = _postService.GetPostByID(id);
            if (posts != null)
                return Ok(posts);
            return NotFound("Post is not found");
        }
        [Authorize(Roles = "staff")]
        [HttpPost("create-post")]
        public IActionResult CreatePost(CreatePostRequest createPost)
        {
            if (_postService.CreatePost(createPost))
                return Ok("Add new post successfully");
            return BadRequest("Can not add new post");
        }
        [Authorize(Roles = "staff")]
        [HttpPut("update-post")]
        public IActionResult UpdatePost(UpdatePostRequest updatePost)
        {

            if (_postService.UpdatePost(updatePost))
                return Ok("Update the post "+ updatePost.Title +" successfully");
            return BadRequest("Can not update the post " + updatePost.Title);
        }
        [Authorize(Roles = "staff")]
        [HttpDelete("delete-post/{id}")]
        public IActionResult DeletePost(int id)
        {
            if (_postService.DeletePost(id))
                return Ok("Deleted the post successfully");
            return BadRequest("Cannot delete post");
        }
        [HttpGet("search-posts")]
        public IActionResult SearchPosts(string title)
        {
            var posts = _postService.SearchPosts(title);
            if (posts.Any())
                return Ok(posts);
            return NotFound("No post found");
        }
        
        [HttpGet("filter-by-age/{age}")]
        public ActionResult<IEnumerable<PostResponse>> FilterByTag(string tag)
        {
            var posts = _postService.FilterbyTag(tag);
            return Ok(posts);
        }

      
    }
}
