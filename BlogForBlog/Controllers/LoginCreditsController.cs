namespace BlogForBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;
using BlogForBlog.Data;

[Route("api/[controller]")]
[ApiController]
public class LoginCreditsController : ControllerBase
{
    private readonly BloggingContext _context;

    public LoginCreditsController(BloggingContext context)
    {
        _context = context;
    }

    // POST: api/LoginCredits
    [HttpPost]
    public async Task<ActionResult<LoginCredits>> CreateLogin(LoginCredits loginCredit)
    {
        _context.LoginCredits.Add(loginCredit);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLoginById), new { id = loginCredit.UserId }, loginCredit);
    }

    // GET: api/LoginCredits/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LoginCredits>> GetLoginById(long id)
    {
        var loginCredit = await _context.LoginCredits.FindAsync(id);
        if (loginCredit == null)
        {
            return NotFound();
        }
        return loginCredit;
    }

    // PUT: api/LoginCredits/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLogin(long id, LoginCredits loginCredit)
    {
        if (id != loginCredit.UserId)
        {
            return BadRequest();
        }

        _context.Entry(loginCredit).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.LoginCredits.Any(e => e.UserId == id))
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
}
