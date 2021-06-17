using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieCommands
{
    public class DeleteMovieCommand : IDeleteMovieCommand
    {
        private readonly CinemaContext _context;

        public DeleteMovieCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 21;

        public string Name => "Remove movie";

        public void Execute(int request)
        {
            var movie = _context.Genres.Find(request);
            if (movie == null)
            {
                throw new EntityNotFoundException(request, typeof(Movie));
            }

            movie.IsDeleted = true;
            movie.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
