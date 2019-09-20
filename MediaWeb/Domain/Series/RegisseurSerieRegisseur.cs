using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Series
{
    public class RegisseurSerieRegisseur
    {
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
        public int RegisseurId { get; set; }
        public SerieRegisseur Regisseur { get; set; }
    }
}
