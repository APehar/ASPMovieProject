using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.UserCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.UserCommands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly CinemaContext _context;

        public DeleteUserCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 25;

        public string Name => "Remove user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
