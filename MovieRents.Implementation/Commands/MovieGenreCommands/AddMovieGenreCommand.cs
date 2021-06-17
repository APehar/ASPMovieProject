using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieGenreDTOs;
using MovieRents.Application.ICommands.MovieGenreCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieGenreCommands
{
    public class AddMovieGenreCommand : IAddMovieGenreCommand
    {
        private readonly CinemaContext _context;
        private readonly AddMovieGenreValidator _validator;

        public AddMovieGenreCommand(CinemaContext context, AddMovieGenreValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 7;

        public string Name => "Add Genre to Movie";

        public void Execute(AddMovieGenreDto request)
        {
            _validator.ValidateAndThrow(request);
            var moviegenre = new MovieGenre
            {
                MovieId = request.MovieId,
                GenreId = request.GenreId
            };
            _context.MovieGenres.Add(moviegenre);
            _context.SaveChanges();
        }
    }
}
