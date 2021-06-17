using FluentValidation;
using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.ICommands.CategoryCommands;
using MovieRents.DataAccess;
using MovieRents.Domain;
using MovieRents.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Commands.CategtoryCommands
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly CinemaContext _context;
        private readonly CategoryValidator _validator;

        public CreateCategoryCommand(CinemaContext context, CategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 2;

        public string Name => "Create new Category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = new Category
            {
                Name = request.Name,
                Price = request.Price
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
