using BloogBloom.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloogBloom.Data
{
    public class BloogBloomDbContext : DbContext
    {
        public BloogBloomDbContext(DbContextOptions<BloogBloomDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostsLike { get; set;}
        public DbSet<BlogPostComment> BlogPostComment { get; set; }

    }
}
