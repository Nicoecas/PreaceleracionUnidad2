using PracticaBlog.Data;
using PracticaBlog.Data.Interfaces;
using PracticaBlog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaBlog.Services
{
    public class UserService:GenericRepository<User>
    {
        public UserService(BlogContext context) : base(context)
        {

        }
    }
}
