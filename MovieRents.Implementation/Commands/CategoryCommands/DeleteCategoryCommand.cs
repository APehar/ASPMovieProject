using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.CategoryCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly CinemaContext _context;

        public DeleteCategoryCommand(CinemaContext context)
        {
            _context = context;
        }

        public int id => 19;

        public string Name => "Remove category";

        public void Execute(int request)
        {
            var catgory = _context.Categories.Find(request);
            if(catgory == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            catgory.IsDeleted = true;
            catgory.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
