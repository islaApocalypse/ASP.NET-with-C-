using System.Collections.Generic;

namespace CinemaConnoissuer2021.Models {
     public class TvCredits {
        public List<TvCast> cast { get; set; }
        public List<TvCrew> crew { get; set; }
        public int id { get; set; }
    }
}