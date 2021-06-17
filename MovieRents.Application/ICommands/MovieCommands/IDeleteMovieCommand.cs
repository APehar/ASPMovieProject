using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.MovieCommands
{
    public interface IDeleteMovieCommand : ICommand<int>
    {
    }
}
