using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.UserCommands
{
    public interface IDeleteUserCommand : ICommand<int>
    {
    }
}
