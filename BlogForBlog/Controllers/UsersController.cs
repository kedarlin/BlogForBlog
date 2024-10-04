namespace BlogForBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;
using BlogForBlog.Data;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly BloggingContext _context;

    public UsersController(BloggingContext context)
    {
        _context = context;
    }

    // POST: api/Users/Register
    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    // GET: api/Users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
