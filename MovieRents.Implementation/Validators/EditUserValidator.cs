using FluentValidation;
using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator(CinemaContext context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email).EmailAddress().WithMessage("Email has to be in the right format");
                });

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Username).NotEmpty()
                .MinimumLength(6)
                .Must((u, n) => !context.Users.Any(x => x.Username == n && x.Id != u.Id)).WithMessage("Username is already taken");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
        }
    }
}
