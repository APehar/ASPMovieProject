
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.UserUseCaseCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.UserUseCaseCommands
{
    public class DeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {
        private readonly CinemaContext _context;

        public DeleteUserUseCaseCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 32;

        public string Name => "Remove usecase from user";

        public void Execute(int request)
        {
            var userusecase = _context.UserUseCases.Find(request);
            if (userusecase == null)
            {
                throw new EntityNotFoundException(request, typeof(UserUseCase));
            }

            _context.UserUseCases.Remove(userusecase);
            _context.SaveChanges();
        }
    }
}
