using Microsoft.EntityFrameworkCore;
using PracticaBlog.Data.Interfaces;
using PracticaBlog.Entities;
using System.Threading.Tasks;

namespace PracticaBlog.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BlogContext blogContext;
        public AuthRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }
        public async Task<bool> ExistUser(string email)
        {
            if (await blogContext.UsersDb.AnyAsync(x => x.EmailAddress == email))
            {
                return true;
            }
            return false;
        }

        public async Task<UserDb> Login(string email, string password)
        {
            var user = await blogContext.UsersDb.FirstOrDefaultAsync(x => x.EmailAddress == email);
            if(user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }
        private bool VerifyPasswordHash(string password,byte[] passwordhash, byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i= 0;i< computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordhash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<UserDb> Register(UserDb user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash= passwordHash;
            user.PasswordSalt= passwordSalt;

            await blogContext.UsersDb.AddAsync(user);
            await blogContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
