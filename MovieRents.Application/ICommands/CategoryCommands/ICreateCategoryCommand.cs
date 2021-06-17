using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.CategoryCommands
{
    public interface ICreateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
