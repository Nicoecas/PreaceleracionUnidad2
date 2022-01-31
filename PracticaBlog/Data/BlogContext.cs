using Microsoft.EntityFrameworkCore;
using PracticaBlog.Entities;

namespace PracticaBlog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserDb> UsersDb { get; set; }
    }
}
