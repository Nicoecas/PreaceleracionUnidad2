using PracticaBlog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaBlog.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<User> AddUser(User user);
        Task<User> PutUser(User user);
        Task<Comment> AddComment(Comment comment);
        Task<Comment> PutComment(Comment comment);
        Task<Post> AddPost(Post post);
        Task<Post> PutPost(Post post);
    }
}
