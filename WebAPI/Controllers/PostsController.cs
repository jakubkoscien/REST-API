using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        { 
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Retrieves all posts")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrieves post by id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create new post")]
        [HttpPost]
        public IActionResult Create(CreatePostDTO newPost) 
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);  
        }

        [SwaggerOperation(Summary = "Update an existing post")]
        [HttpPut]
        public IActionResult Update(UpdatePostDTO newPost)
        {
            _postService.UpdatePost(newPost);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete post by id")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }

    }
}
