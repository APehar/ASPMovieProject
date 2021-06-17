using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieCommands
{
    public class CreateMovieCommand : ICreateMovieCommand
    {
        private readonly CinemaContext _context;
        private readonly CreateMovieValidator _validator;

        public CreateMovieCommand(CinemaContext context, CreateMovieValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 4;

        public string Name => "Create new Movie";

        public void Execute(CreateMovieDto request)
        {
            _validator.ValidateAndThrow(request);

            var movie = new Movie
            {
                Title = request.Title,
                Desc = request.Desc,
                CategoryId = request.CategoryId,
                MovieGenres = request.Genres.Select(x =>
                {
                    var genre = _context.Genres.Find(x.GenreId);
                    return new MovieGenre
                    {
                        GenreId = genre.Id
                    };
                }).ToList()
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
