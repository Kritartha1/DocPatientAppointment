using Microsoft.AspNetCore.Identity;

namespace Appointment.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
