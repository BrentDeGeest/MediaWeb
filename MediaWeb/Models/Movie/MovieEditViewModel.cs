using MediaWeb.Domain.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Movie
{
    public class MovieEditViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Length { get; set; }

        public string Description { get; set; }

        [Required]
        public ICollection<GenreMovieGenre> Genres { get; set; }

        public ICollection<RegisseurMovieRegisseur> Regisseurs { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte[] Cover { get; set; }
    }
}
