using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.ReviewDTOs
{
    public class EditReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
