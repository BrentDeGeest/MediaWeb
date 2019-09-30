using MediaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public List<CheckboxViewModel> Genres { get; set; }
        public ICollection<RegisseurMovieRegisseur> Regisseurs { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public byte[] Cover { get; set; }
    }
}
