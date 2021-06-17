using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.OrderQueries
{
    public interface IGetOneOrderQuery : IQuery<int, OrderDto>
    {
    }
}
