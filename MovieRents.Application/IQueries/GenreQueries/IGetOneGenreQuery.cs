using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.GenreQueries
{
    public interface IGetOneGenreQuery : IQuery<int, GenreDto>
    {
    }
}
