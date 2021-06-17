using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.OrderDTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public string User { get; set; }
        public int MovieId { get; set; }
        public string Movie { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
