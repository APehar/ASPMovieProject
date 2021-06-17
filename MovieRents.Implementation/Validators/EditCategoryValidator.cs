using FluentValidation;
using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryDto>
    {
        public EditCategoryValidator(CinemaContext context)
        {
            RuleFor(x => x.Name).Must((c, n) => !context.Categories.Any(x => x.Name == n && x.Id != c.Id)).WithMessage("Category name already exists");
            RuleFor(x => x.Price).Must(x => x >= 0.1m).WithMessage("Category price must be higher than zero");
        }
    }
}
