using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class CommentSearch : PagedSearch
    {
        public string Content { get; set; }
    }
}
