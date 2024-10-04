namespace BlogForBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;
using BlogForBlog.Data;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly BloggingContext _context;

    public CommentsController(BloggingContext context)
    {
        _context = context;
    }

    // POST: api/Comments
    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    // GET: api/Comments/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(long id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return comment;
    }

    // GET: api/Comments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    // PUT: api/Comments/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(long id, Comment comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        _context.Entry(comment).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comments.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    // DELETE: api/Comments/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(long id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
