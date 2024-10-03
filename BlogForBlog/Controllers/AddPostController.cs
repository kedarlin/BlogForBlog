using BlogForBlog.Models;
using BlogForBlog.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/blogposts")]
[ApiController]
public class AddPostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public AddPostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpPost]
    public async Task<ActionResult> AddPost([FromBody] BlogPost post)
    {
        if (post == null) return BadRequest();

        await _blogPostService.AddPostAsync(post);
        return CreatedAtAction(nameof(GetPostByIdController), new { id = post.Id }, post);
    }
}
