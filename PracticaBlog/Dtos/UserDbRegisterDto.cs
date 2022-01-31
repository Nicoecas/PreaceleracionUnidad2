using System;

namespace PracticaBlog.Dtos
{
    public class UserDbRegisterDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public UserDbRegisterDto()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
