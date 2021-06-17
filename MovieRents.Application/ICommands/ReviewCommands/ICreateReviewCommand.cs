using MovieRents.Application.Data_Transfer.ReviewDTOs;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.ICommands.ReviewCommands
{
    public interface ICreateReviewCommand : ICommand<CreateReviewDto>
    {
    }
}
