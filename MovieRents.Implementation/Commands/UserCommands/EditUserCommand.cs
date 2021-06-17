using FluentValidation;
using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.UserCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.UserCommands
{
    public class EditUserCommand : IEditUserCommand
    {
        private readonly CinemaContext _context;
        private readonly EditUserValidator _validator;

        public EditUserCommand(CinemaContext context, EditUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int id => 12;

        public string Name => "Edit User";

        public void Execute(EditUserDto request)
        {
            var user = _context.Users.Find(request.Id);
            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }
            _validator.ValidateAndThrow(request);

            user.Username = request.Username;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            _context.SaveChanges();
        }
    }
}
