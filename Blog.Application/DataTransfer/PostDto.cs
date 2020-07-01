using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
