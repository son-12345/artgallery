using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtGalleryAPI.Data;
using ArtGalleryAPI.Models;

namespace ArtGalleryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtworksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtworksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artwork>>> GetArtworks()
        {
            return await _context.Artworks.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateArtwork([FromBody] Artwork artwork)
        {
            _context.Artworks.Add(artwork);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Artwork created successfully", artwork });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artwork>> GetArtwork(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null) return NotFound();

            return Ok(artwork);
        }
    }
}
