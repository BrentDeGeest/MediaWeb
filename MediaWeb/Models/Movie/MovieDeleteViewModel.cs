using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Movie
{
    public class MovieDeleteViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public byte[] Cover { get; set; }
    }
}
