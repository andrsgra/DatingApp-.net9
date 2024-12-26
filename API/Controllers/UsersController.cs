using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        if (users == null || !users.Any())
        {
            return NotFound(); // Return 404 if no users found
        }

        return Ok(users); // Return the users with HTTP 200
    }

    [HttpGet("{id:int}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(); // Return 404 if user not found
        }

        return Ok(user); // Return the user with HTTP 200
    }
}
