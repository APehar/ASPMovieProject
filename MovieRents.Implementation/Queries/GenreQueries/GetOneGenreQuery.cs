using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.GenreQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Queries.GenreQueries
{
    public class GetOneGenreQuery : IGetOneGenreQuery
    {
        private readonly CinemaContext _context;

        public GetOneGenreQuery(CinemaContext context)
        {
            _context = context;
        }
        public int id => 16;

        public string Name => "Get one genre";

        public GenreDto Execute(int search)
        {
            var genre = _context.Genres.Find(search);
            if (genre == null)
            {
                throw new EntityNotFoundException(search, typeof(Genre));
            }

            var response = new GenreDto
            {
                Name = genre.Name
            };
            return response;
        }
    }
}
