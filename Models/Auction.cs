namespace ArtGalleryAPI.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "open"; // open hoặc closed
        public ICollection<Bid> Bids { get; set; }
    }
}
