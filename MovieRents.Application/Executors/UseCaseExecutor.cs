using MovieRents.Application.Exceptions;
using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRents.Application.Executors
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor, search);

            if (!actor.AllowedUseCase.Contains(query.id))
            {
                throw new UnauthorizedUseCaseException(query, actor);
            }
            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            logger.Log(command, actor, request);

            if (!actor.AllowedUseCase.Contains(command.id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);
        }
    }
}
