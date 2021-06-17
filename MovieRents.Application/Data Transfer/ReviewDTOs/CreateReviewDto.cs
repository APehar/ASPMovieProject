using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.ReviewDTOs
{
    public class CreateReviewDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
