using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.IQueries.CategoryQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.CategoryQueries
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly CinemaContext _context;

        public GetCategoriesQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 13;

        public string Name => "Search for categories";

        public PageResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= search.MaxPrice);
            }
            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= search.MinPrice);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<CategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto
                {
                    Name = x.Name,
                    Price = x.Price
                }).ToList()
            };

            return response;
        }
    }
}
