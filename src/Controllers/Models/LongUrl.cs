namespace url_shortener.Controllers.Models
{
    public class LongUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ShortUrl shortUrl { get; set; }
    }
}