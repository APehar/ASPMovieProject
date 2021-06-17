using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.MovieDTOs
{
    public class EditMovieDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
