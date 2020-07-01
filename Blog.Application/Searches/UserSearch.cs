using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
