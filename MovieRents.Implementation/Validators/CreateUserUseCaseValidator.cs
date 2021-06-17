using FluentValidation;
using MovieRents.Application.Data_Transfer.UserUsecCaseDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CreateUserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        public CreateUserUseCaseValidator(CinemaContext context)
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("User with the provided id doesent exist");
                });
        }
    }
}
