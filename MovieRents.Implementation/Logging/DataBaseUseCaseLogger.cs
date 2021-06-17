using MovieRents.Application.Interfaces;
using MovieRents.DataAccess;
using MovieRents.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Implementation.Logging
{
    public class DataBaseUseCaseLogger : IUseCaseLogger
    {
        private readonly CinemaContext _context;

        public DataBaseUseCaseLogger(CinemaContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
