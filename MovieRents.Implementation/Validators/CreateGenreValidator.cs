using FluentValidation;
using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CreateGenreValidator : AbstractValidator<GenreDto>
    {
        public CreateGenreValidator(CinemaContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Genre name is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must(x => !context.Genres.Any(y => y.Name == x)).WithMessage("Genre with this name already exists");
                });
        }
    }
}
