using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public string Horror { get; set; }
        public string Comedy { get; set; }
        public string Thriller { get; set; }
    }
}
