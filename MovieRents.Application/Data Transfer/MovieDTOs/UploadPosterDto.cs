using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Data_Transfer.MovieDTOs
{
    public class UploadPosterDto
    {
        public int MovieId { get; set; }
        public IFormFile Poster { get; set; }
    }
}
