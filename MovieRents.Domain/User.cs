using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
    }
}
