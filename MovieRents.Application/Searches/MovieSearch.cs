using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Searches
{
    public class MovieSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
