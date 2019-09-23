﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public IEnumerable<GenreMovieGenre> Genres { get; set; }
        public IEnumerable<RegisseurMovieRegisseur> Regisseurs { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public byte[] Cover { get; set; }
    }
}
