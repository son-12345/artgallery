using Microsoft.AspNetCore.Mvc;
using ArtGalleryAPI.Models;
using ArtGalleryAPI.Services;
using ArtGalleryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (existingUser) return BadRequest("Email already exists!");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user.Id);
            return Ok(new { token });
        }
    }
}
