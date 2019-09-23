using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Movie.Regisseur
{
    public class MovieRegisseurEditViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
