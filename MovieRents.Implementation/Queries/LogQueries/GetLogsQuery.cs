using MovieRents.Application.Data_Transfer.LogDTOs;
using MovieRents.Application.IQueries.LogQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.LogQueries
{
    public class GetLogsQuery : IGetLogsQuery
    {
        private readonly CinemaContext _context;

        public GetLogsQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 35;

        public string Name => "Search for log lines";

        public PageResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var key = search.Keyword.ToLower();
                query = query.Where(x =>
                    x.Actor.ToLower().Contains(key) ||
                    x.UseCaseName.ToLower().Contains(key)
                );
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<LogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new LogDto
                {
                    LogReport = $"{x.Date}: {x.Actor} is trying to execute {x.UseCaseName} using data: " +
                $"{JsonConvert.SerializeObject(x.Data)}"
                }).ToList()
            };

            return response;
        }
    }
}
