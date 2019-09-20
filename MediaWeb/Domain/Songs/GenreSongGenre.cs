using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Songs
{
    public class GenreSongGenre
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int GenreId { get; set; }
        public SongGenre SongGenre { get; set; }
    }
}
