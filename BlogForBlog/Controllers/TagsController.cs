namespace BlogForBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;
using BlogForBlog.Data;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly BloggingContext _context;

    public TagsController(BloggingContext context)
    {
        _context = context;
    }

    // POST: api/Tags
    [HttpPost]
    public async Task<ActionResult<Tag>> PostTag(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
    }

    // GET: api/Tags/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTag(long id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            return NotFound();
        }
        return tag;
    }
}