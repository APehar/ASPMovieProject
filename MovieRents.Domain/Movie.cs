using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
