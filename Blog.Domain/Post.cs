using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
