using BlogForBlog.Models;
using BlogForBlog.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/blogposts")]
[ApiController]

public class GetAllPostsController : ControllerBase{
    private readonly IBlogPostService _blogPostService;

    public GetAllPostsController(IBlogPostService blogPostService){
        _blogPostService = blogPostService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllPosts(){
        var posts = await _blogPostService.GetAllPostsAsync();
        return Ok(posts);
    }
}