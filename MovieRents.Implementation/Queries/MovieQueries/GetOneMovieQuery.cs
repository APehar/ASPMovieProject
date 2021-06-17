using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.MovieQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.MovieQueries
{
    public class GetOneMovieQuery : IGetOneMovieQuery
    {
        private readonly CinemaContext _context;

        public GetOneMovieQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 18;

        public string Name => "Get one movie";

        public MovieDto Execute(int search)
        {
            var movie = _context.Movies
                .Include(x => x.Category)
                .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .FirstOrDefault(x => x.Id == search);
            if (movie == null)
            {
                throw new EntityNotFoundException(search, typeof(Movie));
            }

            var response = new MovieDto
            {
                Title = movie.Title,
                Content = movie.Desc,
                Category = movie.Category.Name,
                Price = movie.Category.Price,
                Genres = movie.MovieGenres.Select(x => x.Genre.Name)
            };
            return response;
        }
    }
}
