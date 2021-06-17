using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.UserQueries
{
    public interface IGetOneUserQuery : IQuery<int, UserDto>
    {
    }
}
