using BloogBloom.Data;
using BloogBloom.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloogBloom.Repository
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloogBloomDbContext bloogBloomDbContext;

        public BlogPostLikeRepository(BloogBloomDbContext bloogBloomDbContext)
        {
            this.bloogBloomDbContext = bloogBloomDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await bloogBloomDbContext.BlogPostsLike.AddAsync(blogPostLike);
            await bloogBloomDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async  Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await bloogBloomDbContext.BlogPostsLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await bloogBloomDbContext.BlogPostsLike.
                CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}


