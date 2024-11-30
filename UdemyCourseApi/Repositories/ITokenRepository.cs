using Microsoft.AspNetCore.Identity;

namespace UdemyCourseApi.Repositories
{
    public interface ITokenRepository
    {
        string createJWTToken(IdentityUser user, List<string>Roles);
    }
}
