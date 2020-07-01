using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class UseCase : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
    }
}
