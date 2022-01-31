using System;

namespace PracticaBlog.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Comment1 { get; set; }

        //user
        public User User { get; set; }
    }
}
