namespace url_shortener.Controllers.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int longUrlId { get; set; }
        public LongUrl longUrl { get; set; }
    }
}