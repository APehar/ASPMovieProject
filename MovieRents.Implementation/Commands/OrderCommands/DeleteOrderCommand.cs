using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.OrderCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.OrderCommands
{
    public class DeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly CinemaContext _context;

        public DeleteOrderCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 28;

        public string Name => "Remove order";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }

            order.IsDeleted = true;
            order.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
