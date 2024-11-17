using BloogBloom.Models.Domain;
using System.Collections;

namespace BloogBloom.Repository
{
    public interface IBlogPostLikeRepository
    {
        Task <int> GetTotalLikes(Guid blogPostId);
        
        Task<IEnumerable<BlogPostLike>>GetLikesForBlog(Guid blogPostId); 
        
        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
    }
}

