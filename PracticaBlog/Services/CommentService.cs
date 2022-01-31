using PracticaBlog.Data;
using PracticaBlog.Entities;

namespace PracticaBlog.Services
{
    public class CommentService : GenericRepository<Comment>
    {
        public CommentService(BlogContext context) : base(context)
        {

        }
    }
}
