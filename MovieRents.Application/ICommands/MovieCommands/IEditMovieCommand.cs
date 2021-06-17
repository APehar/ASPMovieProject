using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.MovieCommands
{
    public interface IEditMovieCommand : ICommand<EditMovieDto>
    {
    }
}
