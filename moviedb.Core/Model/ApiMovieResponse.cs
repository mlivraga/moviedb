using System;
using System.Collections.Generic;

namespace moviedb.Core.Model
{
    public class ApiMovieResponse
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MyMovie> results { get; set; }
    }
}
