using MovieRents.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRents.API.Core
{
    public class FakeAdminActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Test API Admin";

        public IEnumerable<int> AllowedUseCase => Enumerable.Range(1, 100);
    }
}
