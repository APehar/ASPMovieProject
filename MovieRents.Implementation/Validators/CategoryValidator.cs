using FluentValidation;
using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator(CinemaContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must(x => !context.Categories.Any(y => y.Name == x)).WithMessage("Category name is already taken");
                });
            RuleFor(x => x.Price).Must(x => x >= 0.1m).WithMessage("Category price must be higher than 0");
        }
    }
}
