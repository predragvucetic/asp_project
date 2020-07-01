using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Searches
{
    public class LogSearch : PagedSearch
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
    }
}
