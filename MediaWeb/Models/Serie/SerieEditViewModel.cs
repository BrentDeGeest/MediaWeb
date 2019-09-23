using MediaWeb.Domain.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Serie
{
    public class SerieEditViewModel
    {
        [Required]
        public string Name { get; set; }

        public ICollection<RegisseurSerieRegisseur> Regisseurs { get; set; }

        [Required]
        public ICollection<GenreSerieGenre> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
