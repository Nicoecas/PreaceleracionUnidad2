using PracticaBlog.Entities;

namespace PracticaBlog.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserDb user);
    }
}
