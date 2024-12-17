using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtGalleryAPI.Data;
using ArtGalleryAPI.Models;

namespace ArtGalleryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuctionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateAuction([FromBody] Auction auction)
        {
            auction.Status = "open";
            auction.CurrentPrice = auction.StartingPrice;
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Auction created successfully", auction });
        }

        [HttpPost("{id}/bid")]
        public async Task<ActionResult> PlaceBid(int id, [FromBody] Bid bid)
        {
            var auction = await _context.Auctions.Include(a => a.Bids).FirstOrDefaultAsync(a => a.Id == id);
            if (auction == null || auction.Status != "open") return BadRequest("Auction not found or closed.");

            if (bid.BidAmount <= auction.CurrentPrice)
                return BadRequest("Bid must be higher than the current price.");

            bid.AuctionId = id;
            bid.BidTime = DateTime.Now;

            auction.CurrentPrice = bid.BidAmount;
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Bid placed successfully", currentPrice = auction.CurrentPrice });
        }
    }
}
