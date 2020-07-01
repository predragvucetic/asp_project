using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
