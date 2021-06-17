using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.OrderQueries
{
    public interface IGetOrdersQuery : IQuery<OrderSearch, PageResponse<OrderDto>>
    {
    }
}
