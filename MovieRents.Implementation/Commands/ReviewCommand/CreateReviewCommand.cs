using FluentValidation;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.ICommands.ReviewCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.ReviewCommand
{
    public class CreateReviewCommand : ICreateReviewCommand
    {
        private readonly CinemaContext _context;
        private readonly CreateReviewValidator _validator;

        public CreateReviewCommand(CinemaContext context, CreateReviewValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 5;

        public string Name => "Create new Review";

        public void Execute(CreateReviewDto request)
        {
            _validator.ValidateAndThrow(request);
            var review = new Review
            {
                Title = request.Title,
                Content = request.Content,
                UserId = request.UserId,
                MovieId = request.MovieId
            };
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
    }
}
