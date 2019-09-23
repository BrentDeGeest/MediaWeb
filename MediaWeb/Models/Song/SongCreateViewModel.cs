using MediaWeb.Domain.Songs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Song
{
    public class SongCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<SongArtist> Artists { get; set; }

        [Required]
        public ICollection<SongGenre> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
    }
}
