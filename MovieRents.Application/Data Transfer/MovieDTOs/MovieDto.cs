using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.MovieDTOs
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
