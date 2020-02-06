using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Contexts
{
	public class AppDbContext : DbContext
	{
		public DbSet<Url> urls { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Url>().ToTable("url");
			builder.Entity<Url>().HasKey(p => p.shortUrl);
			builder.Entity<Url>().Property(p => p.shortUrl).IsRequired();
			builder.Entity<Url>().Property(p => p.longUrl).IsRequired();
		}
	}
}
