using FluentValidation;
using MovieRents.Application.Data_Transfer.MovieGenreDTOs;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Validators
{
    public class AddMovieGenreValidator : AbstractValidator<AddMovieGenreDto>
    {
        public AddMovieGenreValidator(CinemaContext context)
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.GenreId).Must(x => context.Users.Any(y => y.Id == x)).WithMessage("Genre with the provided id doesent exist");
                });
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.MovieId).Must(x => context.Movies.Any(y => y.Id == x)).WithMessage("Movie with the provided id doesent exist")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.MovieId).Must((m, g) => !context.MovieGenres.Any(x => x.MovieId == m.MovieId && x.GenreId == m.GenreId)).WithMessage("This movie already has this genre");
                    });
                });
        }
    }
}
