using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class Movie
    {

        public int Id { get; set; }
        public string Titel { get; set; }
        public int Lengte { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
