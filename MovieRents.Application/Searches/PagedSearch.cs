using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Searches
{
    public class PagedSearch
    {
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
