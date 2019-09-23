using MediaWeb.Domain.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Movie
{
    public class MovieCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Length { get; set; }

        public string Description { get; set; }

        [Required]
        public IEnumerable<GenreMovieGenre> Genres { get; set; }

        public IEnumerable<RegisseurMovieRegisseur> Regisseurs { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public byte[] Cover { get; set; }
    }
}
