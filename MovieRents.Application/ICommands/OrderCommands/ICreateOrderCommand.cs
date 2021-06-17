using MovieRents.Application.Data_Transfer.OrderDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.OrderCommands
{
    public interface ICreateOrderCommand : ICommand<CreateOrderDto>
    {
    }
}
