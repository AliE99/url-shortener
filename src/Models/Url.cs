namespace url_shortener.Controllers.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string shortUrl { get; set; }
        public string  longUrl { get; set; }
    }
}