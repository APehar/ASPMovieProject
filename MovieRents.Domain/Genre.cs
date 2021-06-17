using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Domain
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }

    }
}
