using Microsoft.AspNetCore.Identity;

namespace BloogBloom.Repository
{
    public interface IUserRepository
    {
      Task<IEnumerable<IdentityUser>>  GetAll();
    }
}
