using MovieRents.Application.Data_Transfer.UserDTOs;
using MovieRents.Application.Interfaces;
using MovieRents.Application.Responers;
using MovieRents.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.IQueries.UserQueries
{
    public interface IGetUsersQuery : IQuery<UserSearch, PageResponse<UserDto>>
    {
    }
}
