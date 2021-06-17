using FluentValidation;
using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.ICommands.UserCommands;
using MovieRents.Application.Interfaces;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.UserCommands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        public int id => 1;

        public string Name => "User registration";

        private readonly CinemaContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;

        public CreateUserCommand(CinemaContext context, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = new User
            {
                Name = request.Name,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };
            _context.Users.Add(user);

            var userusecases = new List<UserUseCase>
            {
                new UserUseCase
                {
                    User = user,
                    UseCaseId = 17
                },
                new UserUseCase
                {
                    User = user,
                    UseCaseId = 18
                },
                new UserUseCase
                {
                    User = user,
                    UseCaseId = 23
                },
                new UserUseCase
                {
                    User = user,
                    UseCaseId = 24
                }
            };
            _context.UserUseCases.AddRange(userusecases);
            _context.SaveChanges();
            _sender.Send(new SendEmailDto
            {
                Content = "<h1>You have successfuly registered your account</h1>",
                SendTo = request.Email,
                Subject = "Welcome!"
            });
        }
    }
}
