using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.MovieGenreDTOs
{
    public class AddMovieGenreDto
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }
    }
}
