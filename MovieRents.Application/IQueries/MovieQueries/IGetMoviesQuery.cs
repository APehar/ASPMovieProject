using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.MovieQueries
{
    public interface IGetMoviesQuery : IQuery<MovieSearch, PageResponse<MovieDto>>
    {
    }
}
