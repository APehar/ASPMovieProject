using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.CategoryQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Queries.CategoryQueries
{
    public class GetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly CinemaContext _context;

        public GetOneCategoryQuery(CinemaContext context)
        {
            _context = context;
        }
        public int id => 14;

        public string Name => "Get one category";

        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);
            if(category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            var response = new CategoryDto
            {
                Name = category.Name,
                Price = category.Price
            };
            return response;
        }
    }
}
