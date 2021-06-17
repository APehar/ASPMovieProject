using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.IQueries.UserQueries;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Queries.UserQueries
{
    public class GetOneUserQuery : IGetOneUserQuery
    {
        private readonly CinemaContext _context;

        public GetOneUserQuery(CinemaContext context)
        {
            _context = context;
        }

        public int id => 26;

        public string Name => "Get one user";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var response = new UserDto
            {
                Username = user.Username,
                Name = user.Name,
                Email = user.Email
            };
            return response;
        }
    }
}
