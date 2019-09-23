using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Podcast.Author
{
    public class AuthorCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string FirstName { get; set; }
    }
}
