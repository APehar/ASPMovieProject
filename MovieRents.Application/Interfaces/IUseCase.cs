using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Interfaces
{
    public interface IUseCase
    {
        int id { get; }
        string Name { get; }
    }

    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
    
}
