using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly DataContext _context = context;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entities.AppUser>>> GetUsers()
    {
#pragma warning disable CS8604 // Possible null reference argument.
        var users = await _context.Users.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
        if (users == null) return NotFound();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return users;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }

    [HttpGet("{id:int}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var user =await context.Users.FindAsync(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (user == null) return NotFound();
        return user;
    }
}