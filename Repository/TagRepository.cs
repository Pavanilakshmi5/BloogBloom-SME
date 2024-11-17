using BloogBloom.Data;
using BloogBloom.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloogBloom.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BloogBloomDbContext bloogBloomDbContext;

        public TagRepository(BloogBloomDbContext bloogBloomDbContext)
        {
            this.bloogBloomDbContext = bloogBloomDbContext;
        }
    
        public async Task<Tag> AddAsync(Tag tag)
        {
            await bloogBloomDbContext.Tags.AddAsync(tag);
            await bloogBloomDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<int> CountAsync()
        {
            return await bloogBloomDbContext.Tags.CountAsync();
        }

        public async Task<Tag> DeleteAsync(Guid id)
        {
            var exsistingTag = await bloogBloomDbContext.Tags.FindAsync(id);    
            if(exsistingTag != null)
            {
                bloogBloomDbContext.Tags.Remove(exsistingTag);
                await bloogBloomDbContext.SaveChangesAsync();
                return exsistingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(
            string? searchQuery,
            string? sortBy,
            string? sortDirection,
            int pageNumber = 1,
            int pageSize = 100)
        {
            var query = bloogBloomDbContext.Tags.AsQueryable();


            if(string.IsNullOrWhiteSpace(searchQuery)==false)
            {
                query = query.Where(x =>x.Name.Contains(searchQuery)||
                x.DisplayName.Contains(searchQuery));
            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                bool isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);

                if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                }

                if (string.Equals(sortBy, "DisplayName", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.DisplayName) : query.OrderBy(x => x.DisplayName);
                }
            }
            var skipResults = (pageNumber - 1) * pageSize;
            query = query.Skip(skipResults).Take(pageSize);

            return await query.ToListAsync();
            //return await bloogBloomDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return bloogBloomDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var exsistingTag = await bloogBloomDbContext.Tags.FindAsync(tag.Id);
            if (exsistingTag != null)
            {
                exsistingTag.Name = tag.Name;
                exsistingTag.DisplayName = tag.DisplayName;
                await bloogBloomDbContext.SaveChangesAsync();
                return exsistingTag;
            }
            return null;
        }
    }
}
