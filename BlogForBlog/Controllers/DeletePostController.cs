using BlogForBlog.Services;
using Microsoft.AspNetCore.Mvc;


[Route("api/blogposts")]
[ApiController]
public class DeletePostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;

    public DeletePostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        await _blogPostService.DeletePostAsync(id);
        return NoContent();
    }
}
