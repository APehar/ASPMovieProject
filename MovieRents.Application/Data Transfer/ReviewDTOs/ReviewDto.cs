using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.ReviewDTOs
{
    public class ReviewDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string User { get; set; }
        public string Movie { get; set; }
    }
}
