using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.IQueries.ReviewQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.ReviewQueries
{
    public class GetReviewsQuery : IGetReviewsQuery
    {
        private readonly CinemaContext _context;

        public GetReviewsQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 23;

        public string Name => "Search for reviews";

        public PageResponse<ReviewDto> Execute(ReviewSearch search)
        {
            var query = _context.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var key = search.Keyword.ToLower();
                query = query.Where(x =>
                    x.Title.ToLower().Contains(key) ||
                    x.Content.ToLower().Contains(key) ||
                    x.Movie.Title.ToLower().Contains(key) ||
                    x.User.Username.ToLower().Contains(key) ||
                    x.User.Name.ToLower().Contains(key)
                );
            }
            if (search.MovieId.HasValue)
            {
                query = query.Where(x => x.MovieId == search.MovieId);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<ReviewDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ReviewDto
                {
                    Title = x.Title,
                    Content = x.Content,
                    Movie = x.Movie.Title,
                    User = x.User.Username

                }).ToList()
            };

            return response;
        }
    }
}
