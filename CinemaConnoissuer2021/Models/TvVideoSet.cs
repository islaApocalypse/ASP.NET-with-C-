using System.Collections.Generic;

namespace CinemaConnoissuer2021.Models {
    public class TvVideoSet
    {
        public int id { get; set; }
        public List<TvVideo> results { get; set; }
    }
}