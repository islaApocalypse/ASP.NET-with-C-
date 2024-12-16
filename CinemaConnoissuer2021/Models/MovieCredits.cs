using System.Collections.Generic;

namespace CinemaConnoissuer2021.Models {
    public class MovieCredits {
        public int id { get; set; }
        public List<MovieCast> cast { get; set; }
        public List<MovieCrew> crew { get; set; }
    }
}