using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.OrderQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.OrderQueries
{
    public class GetOneOrderQuery : IGetOneOrderQuery
    {
        private readonly CinemaContext _context;

        public GetOneOrderQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 29;

        public string Name => "Get one order";

        public OrderDto Execute(int search)
        {
            var order = _context.Orders
                .Include(x => x.Movie)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == search);

            if (order == null)
            {
                throw new EntityNotFoundException(search, typeof(Order));
            }

            var response = new OrderDto
            {
                UserId = order.UserId,
                User = order.User.Username,
                MovieId = order.MovieId,
                Movie = order.Movie.Title
            };
            return response;
        }
    }
}
