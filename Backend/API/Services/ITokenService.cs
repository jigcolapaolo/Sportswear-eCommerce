using API.Entities.Identity;

namespace API.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}
