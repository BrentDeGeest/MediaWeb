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
        //public ICollection<GenreMovieGenre> Genres { get; set; }
        //public List<string> Genresd { get; set; }
        public List<CheckboxViewModel> Genres { get; set; } = new List<CheckboxViewModel>();

        public List<RegisseurMovieRegisseur> Regisseurs { get; set; } = new List<RegisseurMovieRegisseur>();

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public byte[] Cover { get; set; }

        public MovieCreateViewModel()
        {
            //Genres = new List<GenreMovieGenre>();
            //Regisseurs = new List<RegisseurMovieRegisseur>();
            //Genresd = new List<string>();
        }
    }
}
