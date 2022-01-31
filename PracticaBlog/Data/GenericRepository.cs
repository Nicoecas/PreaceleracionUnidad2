using Microsoft.EntityFrameworkCore;
using PracticaBlog.Data.Interfaces;
using PracticaBlog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaBlog.Data
{
    public class GenericRepository <TEntity>: IGenericRepository <TEntity> where TEntity : class
    {
        private readonly BlogContext _blogContext;
        public GenericRepository(BlogContext _blogContext)
        {
            this._blogContext = _blogContext;
        }

        //Delete and Get generic
        public async Task<TEntity> Delete(int id)
        {
            var entity = await _blogContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _blogContext.Set<TEntity>().Remove(entity);
            await _blogContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _blogContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _blogContext.Set<TEntity>().FindAsync(id);
        }


        //Post and Put Comment
        public async Task<Comment> AddComment(Comment comment)
        {
            await _blogContext.Comments.AddAsync(comment);
            await _blogContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> PostComment(Comment comment)
        {
            var internalvariable = await _blogContext.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id);
            internalvariable.Comment1 = comment.Comment1;
            _blogContext.SaveChanges();
            return comment;
        }



        //Post and Put Post
        public async Task<Post> AddPost(Post post)
        {
            await _blogContext.Posts.AddAsync(post);
            await _blogContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> PostPost(Post post)
        {
            var internalvariable = await _blogContext.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
            internalvariable.Title = post.Title;
            internalvariable.Content = post.Content;
            _blogContext.SaveChanges();
            return post;
        }



        //Post and Put User
        public async Task<User> AddUser(User user)
        {
            await _blogContext.Users.AddAsync(user);
            await _blogContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> PostUser(User user)
        {
            var internalvariable = await _blogContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            internalvariable.Name = user.Name;
            internalvariable.Password= user.Password;
            internalvariable.Email= user.Email;
            _blogContext.SaveChanges();
            return user;
        }
    }
}
