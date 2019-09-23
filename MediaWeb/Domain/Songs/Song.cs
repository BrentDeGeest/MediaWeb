using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Songs
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongArtist> Artists { get; set; }
        public ICollection<SongGenre> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
    }
}
