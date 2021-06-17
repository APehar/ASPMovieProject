using FluentValidation;
using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class EditGenreValidator : AbstractValidator<EditGenreDto>
    {
        public EditGenreValidator(CinemaContext context)
        {
            RuleFor(x => x.Name).Must((g, n) => !context.Categories.Any(x => x.Name == n && x.Id != g.Id)).WithMessage("Genre name already exists");
        }
    }
}
