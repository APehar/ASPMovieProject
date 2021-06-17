using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.CategoryQueries
{
    public interface IGetOneCategoryQuery : IQuery<int, CategoryDto>
    {
    }
}
