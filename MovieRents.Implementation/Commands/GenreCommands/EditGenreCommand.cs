using FluentValidation;
using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.GenreCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.GenreCommands
{
    public class EditGenreCommand : IEditGenreCommand
    {
        private readonly CinemaContext _context;
        private readonly EditGenreValidator _validator;

        public EditGenreCommand(CinemaContext context, EditGenreValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 9;

        public string Name => "Edit genre";

        public void Execute(EditGenreDto request)
        {
            var genre = _context.Genres.Find(request.Id);
            if(genre == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Genre));
            }

            _validator.ValidateAndThrow(request);

            genre.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
