using Microsoft.AspNetCore.Identity;

namespace ProjectManagerApi.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
