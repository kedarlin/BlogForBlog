using BlogForBlog.Models;
using BlogForBlog.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/blogposts")]
[ApiController]

public class GetPostByIdController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public GetPostByIdController(IBlogPostService blogPostService){
        _blogPostService = blogPostService;
    }

    [HttpGet("id")]
    public async Task<ActionResult<BlogPost>> GetPostById(int id){
        var blogPost = await _blogPostService.GetPostByIdAsync(id);
        if(blogPost == null){
            return NotFound();
        }
        return Ok(blogPost);
    }
}