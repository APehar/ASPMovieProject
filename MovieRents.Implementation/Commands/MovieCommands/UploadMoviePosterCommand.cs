using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieRents.Implementation.Commands.MovieCommands
{
    public class UploadMoviePosterCommand : IUploadMoviePosterCommand
    {
        private readonly CinemaContext _context;

        public UploadMoviePosterCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 34;

        public string Name => "Upload movie poster";

        public void Execute(UploadPosterDto request)
        {
            var movie = _context.Movies.Find(request.MovieId);
            if(movie == null)
            {
                throw new EntityNotFoundException(request.MovieId, typeof(Movie));
            }

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Poster.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "Images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Poster.CopyTo(fileStream);
            }

            movie.ImagePath = path;
            _context.SaveChanges();

        }
    }
}
