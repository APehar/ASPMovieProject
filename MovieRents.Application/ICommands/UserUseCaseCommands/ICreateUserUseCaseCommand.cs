using MovieRents.Application.Data_Transfer.UserUsecCaseDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.UserUseCaseCommands
{
    public interface ICreateUserUseCaseCommand : ICommand<UserUseCaseDto>
    {
    }
}
