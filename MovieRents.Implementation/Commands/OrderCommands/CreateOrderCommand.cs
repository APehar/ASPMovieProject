using FluentValidation;
using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.ICommands.OrderCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.OrderCommands
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly CinemaContext _context;
        private readonly CreateOrderValidator _validator;

        public CreateOrderCommand(CinemaContext context, CreateOrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 6;

        public string Name => "Create new Order";

        public void Execute(CreateOrderDto request)
        {
            _validator.ValidateAndThrow(request);
            var order = new Order
            {
                UserId = request.UserId,
                MovieId = request.MovieId
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
