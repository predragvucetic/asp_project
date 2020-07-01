using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class PostSearch : PagedSearch
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
