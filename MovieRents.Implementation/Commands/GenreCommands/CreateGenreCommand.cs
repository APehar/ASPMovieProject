using FluentValidation;
using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.ICommands.GenreCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.GenreCommands
{
    public class CreateGenreCommand : ICreateGenreCommand
    {
        private readonly CinemaContext _context;
        private readonly CreateGenreValidator _validator;

        public CreateGenreCommand(CinemaContext context, CreateGenreValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 3;

        public string Name => "Create new Genre";

        public void Execute(GenreDto request)
        {
            _validator.ValidateAndThrow(request);
            var genre = new Genre
            {
                Name = request.Name
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
