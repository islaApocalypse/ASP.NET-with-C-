using System;

namespace CinemaConnoissuer2021.Models {
    public class MovieVideo {
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string site { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public bool official { get; set; }
        public string id { get; set; }
    }
}