﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Responers
{
    public class PageResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public IEnumerable<T> Items { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
    }
}
