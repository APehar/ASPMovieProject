using MovieRents.Application.Data_Transfer.MovieGenreDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.MovieGenreCommands
{
    public interface IAddMovieGenreCommand : ICommand<AddMovieGenreDto>
    {
    }
}
