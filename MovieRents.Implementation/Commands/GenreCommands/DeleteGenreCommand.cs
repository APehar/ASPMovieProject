using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.GenreCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.GenreCommands
{
    public class DeleteGenreCommand : IDeleteGenreCommand
    {
        private readonly CinemaContext _context;

        public DeleteGenreCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 20;

        public string Name => "Remove genre";

        public void Execute(int request)
        {
            var genre = _context.Genres.Find(request);
            if (genre == null)
            {
                throw new EntityNotFoundException(request, typeof(Genre));
            }

            genre.IsDeleted = true;
            genre.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
