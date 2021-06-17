using FluentValidation;
using MovieRents.Application.Data_Transfer.UserUsecCaseDTOs;
using MovieRents.Application.ICommands.UserUseCaseCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.UserUseCaseCommands
{
    public class CreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly CinemaContext _context;
        private readonly CreateUserUseCaseValidator _validator;

        public CreateUserUseCaseCommand(CinemaContext context, CreateUserUseCaseValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 33;

        public string Name => "Add new usecase to user";

        public void Execute(UserUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);
            var useruscecase = new UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = request.UseCaseId
            };
            _context.UserUseCases.Add(useruscecase);
            _context.SaveChanges();
        }
    }
}
