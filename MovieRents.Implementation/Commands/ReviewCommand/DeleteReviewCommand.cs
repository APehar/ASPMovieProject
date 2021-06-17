using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.ReviewCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.ReviewCommand
{
    public class DeleteReviewCommand : IDeleteReviewCommand
    {
        private readonly CinemaContext _context;

        public DeleteReviewCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 22;

        public string Name => "Remove review";

        public void Execute(int request)
        {
            var review = _context.Reviews.Find(request);
            if (review == null)
            {
                throw new EntityNotFoundException(request, typeof(Review));
            }

            review.IsDeleted = true;
            review.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
