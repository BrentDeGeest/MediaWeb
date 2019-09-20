using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class RegisseurMovieRegisseur
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int RegisseurId { get; set; }
        public MovieRegisseur Regisseur { get; set; }
    }
}
