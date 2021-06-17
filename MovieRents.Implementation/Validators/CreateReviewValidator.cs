using FluentValidation;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidator(CinemaContext context)
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Review content is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Review title is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Title).Must((r, t) => !context.Reviews.Any(x => x.Title == t && x.MovieId != r.MovieId)).WithMessage("This movie already has a review with the same name");
                });
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("User with the provided id doesent exist");
                });
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.MovieId).Must(x => context.Movies.Any(y => y.Id == x)).WithMessage("Movie with the provided id doesent exist");
                });
        }
    }
}
