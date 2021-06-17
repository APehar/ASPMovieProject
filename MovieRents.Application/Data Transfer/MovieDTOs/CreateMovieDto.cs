using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.MovieDTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CreateMovieGenreDto> Genres { get; set; } = new List<CreateMovieGenreDto>();
    }

    public class CreateMovieGenreDto
    {
        public int GenreId { get; set; }
    }
}
