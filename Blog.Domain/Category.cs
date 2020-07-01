using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
