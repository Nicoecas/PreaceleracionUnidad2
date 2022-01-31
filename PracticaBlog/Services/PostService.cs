using PracticaBlog.Data;
using PracticaBlog.Entities;

namespace PracticaBlog.Services
{
    public class PostService : GenericRepository<Post>
    {
        public PostService(BlogContext context) : base(context)
        {

        }
    }
}
