using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
