using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Interfaces
{
    public interface IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
