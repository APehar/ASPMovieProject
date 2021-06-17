using FluentValidation;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class EditReviewValidator : AbstractValidator<EditReviewDto>
    {
        public EditReviewValidator(CinemaContext context)
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Review content is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Review title is required");
        }
    }
}
