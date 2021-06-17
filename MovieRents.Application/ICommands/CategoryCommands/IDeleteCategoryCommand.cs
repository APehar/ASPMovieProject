using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.CategoryCommands
{
    public interface IDeleteCategoryCommand : ICommand<int>
    {
    }
}
