using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.GenreCommands
{
    public interface IEditGenreCommand : ICommand<EditGenreDto>
    {
    }
}
