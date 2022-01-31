using PracticaBlog.Entities;
using System.Threading.Tasks;

namespace PracticaBlog.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserDb> Register(UserDb user, string password);
        Task<UserDb> Login(string email, string password);
        Task<bool> ExistUser(string email);
    }
}
