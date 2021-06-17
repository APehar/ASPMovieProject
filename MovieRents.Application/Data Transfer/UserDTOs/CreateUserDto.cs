using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.UserDTOs
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
