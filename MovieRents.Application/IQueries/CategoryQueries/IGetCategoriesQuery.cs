using MovieRents.Application.Data_Transfer.CategoryDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.CategoryQueries
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch, PageResponse<CategoryDto>>
    {
    }
}
