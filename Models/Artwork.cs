namespace ArtGalleryAPI.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public ICollection<Auction> Auctions { get; set; }
    }
}
