using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Image : BaseEntity
    {
        public string ImageName { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
