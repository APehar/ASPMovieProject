using MovieRents.Application.Data_Transfer.LogDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.LogQueries
{
    public interface IGetLogsQuery : IQuery<LogSearch, PageResponse<LogDto>>
    {
    }
}
