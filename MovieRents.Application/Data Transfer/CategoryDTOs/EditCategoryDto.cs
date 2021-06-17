using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.CategoryDTOs
{
    public class EditCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
