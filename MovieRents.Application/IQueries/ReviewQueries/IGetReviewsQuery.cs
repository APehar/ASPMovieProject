using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.ReviewQueries
{
    public interface IGetReviewsQuery : IQuery<ReviewSearch, PageResponse<ReviewDto>>
    {
    }
}
