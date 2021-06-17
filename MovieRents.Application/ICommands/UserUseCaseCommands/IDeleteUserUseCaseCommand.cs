using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.UserUseCaseCommands
{
    public interface IDeleteUserUseCaseCommand : ICommand<int>
    {
    }
}
