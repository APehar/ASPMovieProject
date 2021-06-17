using Microsoft.EntityFrameworkCore;
using MovieRents.Application.Data_Transfer.MovieDTOs;
using MovieRents.Application.IQueries.MovieQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.MovieQueries
{
    public class GetMoviesQuery : IGetMoviesQuery
    {
        private readonly CinemaContext _context;

        public GetMoviesQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 17;

        public string Name => "Search for movies";

        public PageResponse<MovieDto> Execute(MovieSearch search)
        {
            var query = _context.Movies
                .Include(x => x.Category)
                .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var key = search.Keyword.ToLower();
                query = query.Where(x => 
                    x.Title.ToLower().Contains(key) ||
                    x.Desc.ToLower().Contains(key) ||
                    x.Category.Name.ToLower().Contains(key) ||
                    x.MovieGenres.Any(x => x.Genre.Name.ToLower().Contains(key))
                );
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Category.Price <= search.MaxPrice);
            }
            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Category.Price >= search.MinPrice);
            }
            if (search.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == search.CategoryId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<MovieDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new MovieDto
                {
                    Title = x.Title,
                    Content = x.Desc,
                    Category = x.Category.Name,
                    Price = x.Category.Price,
                    Genres = x.MovieGenres.Select(x => x.Genre.Name)

                }).ToList()
            };

            return response;
        }
    }
}
