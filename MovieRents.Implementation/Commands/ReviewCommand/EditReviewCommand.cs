using FluentValidation;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.ReviewCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.ReviewCommand
{
    public class EditReviewCommand : IEditReviewCommand
    {
        private readonly CinemaContext _context;
        private readonly EditReviewValidator _validator;

        public EditReviewCommand(CinemaContext context, EditReviewValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int id => 11;

        public string Name => "Edit review";

        public void Execute(EditReviewDto request)
        {
            var review = _context.Reviews.Find(request.Id);
            if (review == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Review));
            }
            _validator.ValidateAndThrow(request);

            review.Title = request.Title;
            review.Content = request.Content;
            _context.SaveChanges();
        }
    }
}
