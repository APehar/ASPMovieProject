using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.GenreQueries
{
    public interface IGetGenresQuery : IQuery<GenreSearch, PageResponse<GenreDto>>
    {
    }
}
