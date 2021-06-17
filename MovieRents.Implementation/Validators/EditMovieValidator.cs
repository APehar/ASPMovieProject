using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class EditMovieValidator : AbstractValidator<EditMovieDto>
    {
        public EditMovieValidator(CinemaContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Movie title is required");
            RuleFor(x => x.Desc).NotEmpty().WithMessage("Movie description is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Movie category is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CategoryId).Must(x => context.Categories.Any(y => y.Id == x)).WithMessage("Thre is no category with the given id");
                });
        }
    }
}
