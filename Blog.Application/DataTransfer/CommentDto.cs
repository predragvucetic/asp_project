using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}