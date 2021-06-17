using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Searches
{
    public class ReviewSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
    }
}
