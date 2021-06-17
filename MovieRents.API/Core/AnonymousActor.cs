using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRents.API.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymous User";

        public IEnumerable<int> AllowedUseCase => new List<int> { 1 };
    }
}
