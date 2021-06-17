using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.MovieGenreCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieGenreCommands
{
    public class DeleteMovieGenreCommand : IDeleteMovieGenreCommand
    {
        private readonly CinemaContext _context;

        public DeleteMovieGenreCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 31;

        public string Name => "Remove genre from movie";

        public void Execute(int request)
        {
            var moviegenre = _context.MovieGenres.Find(request);
            if(moviegenre == null)
            {
                throw new EntityNotFoundException(request, typeof(MovieGenre));
            }

            _context.MovieGenres.Remove(moviegenre);
            _context.SaveChanges();
        }
    }
}
