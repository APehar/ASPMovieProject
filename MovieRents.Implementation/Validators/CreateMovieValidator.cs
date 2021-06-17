using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieValidator(CinemaContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Movie title is required");
            RuleFor(x => x.Desc).NotEmpty().WithMessage("Movie description is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Movie category is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CategoryId).Must(x => context.Categories.Any(y => y.Id == x)).WithMessage("Thre is no category with the given id");
                });
            RuleFor(x => x.Genres).NotEmpty().WithMessage("Movie genres are required")
                .DependentRules((Action)(() =>
                {
                    RuleFor(x => x.Genres).Must(x =>
                    {
                        var distinctid = x.Select(x => x.GenreId).Distinct();
                        return distinctid.Count() == x.Count();
                    }).WithMessage("Duplicate genres are not allowed")
                    .DependentRules((Action)(() =>
                    {
                        RuleForEach(x => x.Genres).SetValidator((IValidator<CreateMovieGenreDto>)new CreateMovieGenreValidator((CinemaContext)context));
                    }));
                }));
        }
    }

    public class CreateMovieGenreValidator : AbstractValidator<CreateMovieGenreDto>
    {
        public CreateMovieGenreValidator(CinemaContext context)
        {
            RuleFor(x => x.GenreId).Must(x => context.Genres.Any(y => y.Id == x)).WithMessage("Thre is no genre with the given id");
        }
    }
}
