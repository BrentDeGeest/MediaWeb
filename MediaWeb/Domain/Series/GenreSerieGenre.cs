﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Series
{
    public class GenreSerieGenre
    {
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
        public int GenreId { get; set; }
        public SerieGenre Genre { get; set; }
    }
}
