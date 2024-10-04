namespace BlogForBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;
using BlogForBlog.Data;



[Route("api/[controller]")]
[ApiController]
public class TagDetailsController : ControllerBase
{
    private readonly BloggingContext _context;

    public TagDetailsController(BloggingContext context)
    {
        _context = context;
    }

    // POST: api/TagDetails
    [HttpPost]
    public async Task<ActionResult<TagDetail>> PostTagDetail(TagDetail tagDetail)
    {
        _context.TagDetails.Add(tagDetail);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTagDetail), new { id = tagDetail.Id }, tagDetail);
    }

    // GET: api/TagDetails/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TagDetail>> GetTagDetail(long id)
    {
        var tagDetail = await _context.TagDetails.FindAsync(id);
        if (tagDetail == null)
        {
            return NotFound();
        }
        return tagDetail;
    }

    // GET: api/TagDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagDetail>>> GetTagDetails()
    {
        return await _context.TagDetails.ToListAsync();
    }
}