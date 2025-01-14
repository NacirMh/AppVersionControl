using AppVersionControlApi.Entities;

namespace AppVersionControlApi.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(AppUser user);
    }
}
