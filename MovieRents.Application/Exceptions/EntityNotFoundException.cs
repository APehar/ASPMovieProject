using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type) : base($"Entity with type {type.Name} and with an id of {id} was not found.") { }
    }
}
