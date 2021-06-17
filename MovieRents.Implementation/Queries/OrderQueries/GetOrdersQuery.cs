using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.IQueries.OrderQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.OrderQueries
{
    public class GetOrdersQuery : IGetOrdersQuery
    {
        private readonly CinemaContext _context;

        public GetOrdersQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 30;

        public string Name => "Search for orders";

        public PageResponse<OrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders
                .Include(x => x.Movie)
                .Include(x => x.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var key = search.Keyword.ToLower();
                query = query.Where(x => 
                    x.Movie.Title.ToLower().Contains(key) ||
                    x.User.Username.ToLower().Contains(key)
                );
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<OrderDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new OrderDto
                {
                    UserId = x.UserId,
                    User = x.User.Username,
                    MovieId = x.MovieId,
                    Movie = x.Movie.Title
                }).ToList()
            };

            return response;
        }
    }
}
