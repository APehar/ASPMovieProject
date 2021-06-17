using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.IQueries.UserQueries;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using MovieRents.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Implementation.Queries.UserQueries
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly CinemaContext _context;

        public GetUsersQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 27;

        public string Name => "Search for users";

        public PageResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var key = search.Keyword.ToLower();
                query = query.Where(x =>
                    x.Username.ToLower().Contains(key) ||
                    x.Name.ToLower().Contains(key) ||
                    x.Email.ToLower().Contains(key)
                );
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PageResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    Username = x.Username,
                    Name = x.Name,
                    Email = x.Email
                }).ToList()
            };

            return response;
        }
    }
}
