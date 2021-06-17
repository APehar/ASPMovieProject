using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Interfaces
{
    public interface IApplicationActor
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> AllowedUseCase { get; }
    }

}
