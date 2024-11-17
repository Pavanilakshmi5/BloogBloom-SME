using BloogBloom.Data;
using BloogBloom.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloogBloom.Repository
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BloogBloomDbContext bloogBloomDbContext;

        public BlogPostCommentRepository(BloogBloomDbContext bloogBloomDbContext)
        {
            this.bloogBloomDbContext = bloogBloomDbContext;
        }
        public async  Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await bloogBloomDbContext.BlogPostComment.AddAsync(blogPostComment);
            await bloogBloomDbContext.SaveChangesAsync();   
            return blogPostComment; 
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
           return  await bloogBloomDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
