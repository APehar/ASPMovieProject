using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieCommands
{
    public class EditMovieCommand : IEditMovieCommand
    {
        private readonly CinemaContext _context;
        private readonly EditMovieValidator _validator;

        public EditMovieCommand(CinemaContext context, EditMovieValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int id => 10;

        public string Name => "Edit movie";

        public void Execute(EditMovieDto request)
        {
            var movie = _context.Movies.Find(request.Id);
            if (movie == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Movie));
            }
            _validator.ValidateAndThrow(request);

            movie.Title = request.Title;
            movie.Desc = request.Desc;
            movie.CategoryId = request.CategoryId;
            _context.SaveChanges();
        }
    }
}
