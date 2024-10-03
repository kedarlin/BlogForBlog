using BlogForBlog.Models;
using BlogForBlog.Services;
using Microsoft.AspNetCore.Mvc;


[Route("api/blogposts")]
[ApiController]
public class UpdatePostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public UpdatePostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, [FromBody] BlogPost post)
    {
        if (post == null || post.Id != id) return BadRequest();

        await _blogPostService.UpdatePostAsync(id, post);
        return NoContent();
    }
}
