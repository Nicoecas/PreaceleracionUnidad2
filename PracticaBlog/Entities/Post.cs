using System;

namespace PracticaBlog.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }

        //User
        public User User { get; set; }
    }
}
