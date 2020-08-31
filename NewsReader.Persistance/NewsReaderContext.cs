using Microsoft.EntityFrameworkCore;
using NewsReader.Persistance.Entities;

namespace NewsReader.Persistance
{
    public class NewsReaderContext : DbContext
    {
        public NewsReaderContext(DbContextOptions<NewsReaderContext> options)
            : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>().HasKey(Article => Article.ArticleId);
            builder.Entity<Source>().HasKey(Source => Source.SourceGuid);
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Source> Source { get; set; }
    }
}
