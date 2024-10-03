using Microsoft.AspNetCore.Mvc;
using BlogForBlog.Models;
using BlogForBlog.Services;

[Route("api/[controller]")]
[ApiController]

public class BlogPostController : ControllerBase{
    private readonly IBlogPostService _blogPostService;

    public BlogPostController(IBlogPostService blogPostService){
        _blogPostService = blogPostService;
    }
}




// namespace BlogForBlog.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class BlogPostsController : ControllerBase{
//         private readonly BlogPostService _service;

//         public BlogPostsController(BlogPostService service){
//             _service = service;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts(){
//             var blogPosts = await _service.GetAllBlogPostAsync();
//             return Ok(blogPosts);
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<BlogPost>> GetBlogPost(int id){
//             var blogPost = await _service.GetBlogPostByIdAsync(id);
//             if(blogPost == null){
//                 return NotFound();
//             }
//             return Ok(blogPost);
//         }

//         [HttpPost]
//         public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost){
//             await _service.AddBLogPostAsync(blogPost);
//             return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id}, blogPost);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost){
//             if(id != blogPost.Id){
//                 return BadRequest();
//             }

//             if(!_service.BlogPostExists(id)){
//                 return NotFound();
//             }
//             await _service.UpdateBlogPostAsync(blogPost);

//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteBlogPost(int id){
//             if(!_service.BlogPostExists(id)){
//                 return NotFound();
//             }
//             await _service.DeleteBlogPostAsync(id);
//             return NoContent();
//         }
//     }
// }