using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Song.Genre
{
    public class SongGenreCreateViewModel
    {
        [Required]
        public string Name { get; set; }

    }
}
