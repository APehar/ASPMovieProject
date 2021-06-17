using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.ReviewQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.ReviewQueries
{
    public class GetOneReviewQuery : IGetOneReviewQuery
    {
        private readonly CinemaContext _context;

        public GetOneReviewQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 24;

        public string Name => "Get one review";

        public ReviewDto Execute(int search)
        {
            var review = _context.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == search);

            if (review == null)
            {
                throw new EntityNotFoundException(search, typeof(Review));
            }

            var response = new ReviewDto
            {
                Title = review.Title,
                Content = review.Content,
                Movie = review.Movie.Title,
                User = review.User.Username
            };
            return response;
        }
    }
}
