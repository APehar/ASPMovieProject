using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
