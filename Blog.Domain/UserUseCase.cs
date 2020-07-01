using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
        public virtual UseCase UseCase { get; set; }
    }
}
