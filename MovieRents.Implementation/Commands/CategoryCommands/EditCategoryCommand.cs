using FluentValidation;
using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.Exceptions;
using MovieRents.Application.ICommands.CategoryCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.CategoryCommands
{
    public class EditCategoryCommand : IEditCategoryCommand
    {
        private readonly CinemaContext _context;
        private readonly EditCategoryValidator _validator;

        public EditCategoryCommand(CinemaContext context, EditCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 8;

        public string Name => "Edit category";

        public void Execute(EditCategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);
            if(category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }
            _validator.ValidateAndThrow(request);

            category.Name = request.Name;
            category.Price = request.Price;
            _context.SaveChanges();
        }
    }
}
