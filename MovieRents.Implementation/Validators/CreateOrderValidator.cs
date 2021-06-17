using FluentValidation;
using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator(CinemaContext context)
        {
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
