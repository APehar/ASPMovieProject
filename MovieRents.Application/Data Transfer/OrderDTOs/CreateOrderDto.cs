using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.OrderDTOs
{
    public class CreateOrderDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
