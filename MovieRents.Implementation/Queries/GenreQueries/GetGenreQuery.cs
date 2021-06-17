using MovieRents.Application.Data_Transfer.GenreDTOs;
using MovieRents.Application.IQueries.GenreQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.GenreQueries
{
    public class GetGenreQuery : IGetGenresQuery
    {
        private readonly CinemaContext _context;

        public GetGenreQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 15;

        public string Name => "Search for genres";

        public PageResponse<GenreDto> Execute(GenreSearch search)
        {
            var query = _context.Genres.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<GenreDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GenreDto
                {
                    Name = x.Name,
                }).ToList()
            };

            return response;
        }
    }
}
