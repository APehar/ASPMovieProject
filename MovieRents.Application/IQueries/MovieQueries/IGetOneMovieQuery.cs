using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.MovieQueries
{
    public interface IGetOneMovieQuery : IQuery<int, MovieDto>
    {
    }
}
