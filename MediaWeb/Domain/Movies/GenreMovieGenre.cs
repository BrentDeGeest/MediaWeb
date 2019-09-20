﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movies
{
    public class GenreMovieGenre
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
