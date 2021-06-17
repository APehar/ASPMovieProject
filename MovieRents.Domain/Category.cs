using System;
using System.Collections.Generic;

namespace MovieRents.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
