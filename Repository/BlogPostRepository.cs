using BloogBloom.Data;
using BloogBloom.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloogBloom.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloogBloomDbContext bloogBloomDbContext;

        public BlogPostRepository(BloogBloomDbContext bloogBloomDbContext) 
        {
            this.bloogBloomDbContext = bloogBloomDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogpost)
        {
            await bloogBloomDbContext.AddAsync(blogpost);
            await bloogBloomDbContext.SaveChangesAsync();
            return blogpost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await bloogBloomDbContext.BlogPosts.FindAsync(id);
            if (existingBlog != null)
            {
                bloogBloomDbContext.BlogPosts.Remove(existingBlog);
                await bloogBloomDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await bloogBloomDbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await bloogBloomDbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x=>x.Id == id);  
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await bloogBloomDbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogpost)
        {
            var exsistingBlog = await bloogBloomDbContext.BlogPosts.Include(x=>x.Tags)
                .FirstOrDefaultAsync(x=> x.Id == blogpost.Id);
            if(exsistingBlog != null) 
            {
                exsistingBlog.Id = blogpost.Id;
                exsistingBlog.Heading = blogpost.Heading;
                exsistingBlog.PageTitle = blogpost.PageTitle;
                exsistingBlog.Content = blogpost.Content;
                exsistingBlog.ShortDescription = blogpost.ShortDescription;
                exsistingBlog.Author = blogpost.Author;
                exsistingBlog.FeaturedImageUrl = blogpost.FeaturedImageUrl;
                exsistingBlog.UrlHandle = blogpost.UrlHandle;
                exsistingBlog.Visibile = blogpost.Visibile;
                exsistingBlog.PublishedDate = blogpost.PublishedDate;
                exsistingBlog.Tags = blogpost.Tags;
                await bloogBloomDbContext.SaveChangesAsync();
                return exsistingBlog;
            }
            return null;
        }
    }
}
