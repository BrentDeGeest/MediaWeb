using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Series
{
    public class Serie
    {
        public int Id { get; set; }
        public ICollection<RegisseurSerieRegisseur> Regisseurs { get; set; }
        public ICollection<GenreSerieGenre> Genres { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
