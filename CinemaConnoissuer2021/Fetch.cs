
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using CinemaConnoissuer2021.Models;

namespace CinemaConnoissuer2021 {
    public class Fetch {
        public HttpClient client = new HttpClient();
        public const string API_KEY = "d53de5e1d50eaaca98c1ca40da6701a9";
        public string Data { get; set; }
        public string Videos { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }

        public async Task TrendingMovie() {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/popular?api_key=" + 
                API_KEY);
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.trendingMovieSet = JsonSerializer.Deserialize<TrendingMovieSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task TrendingTv() {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/tv/popular?api_key=" + 
                API_KEY);
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.trendingTvSet = JsonSerializer.Deserialize<TrendingTvSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task TvSearch(string search) {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/tv?api_key=" + API_KEY + 
                "&query=" + search);
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.tvSet = JsonSerializer.Deserialize<TvSet>(Data);
            }
            else {
                Data = null;
            }
        } // TvSearch()
        
        public async Task MovieSearch(string search) {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/movie?api_key=" + API_KEY + 
                "&query=" + search);
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.movieSet = JsonSerializer.Deserialize<MovieSet>(Data);
            }
            else {
                Data = null;
            }
        } // TvSearch()
        
            public async Task GetMovieDetails(string movieID) {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID + 
                "?api_key=" + API_KEY + "&language=en-US");
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.movie = JsonSerializer.Deserialize<Movie>(Data);
            }
            else {
                Data = null;
            }
        } // GetMovieDetails()

        public async Task GetTvDetails(string tvID) {
            ClearHeaders();

            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/tv/" + tvID + "?api_key=" + API_KEY +
                "&language=en-US");
            
            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.tvShow = JsonSerializer.Deserialize<TvShow>(Data);
            }
            else {
                Data = null;
            }
        } // GetTvDetails()

        public async Task GetMovieCast(string movieID) {
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" +
                    movieID + "/credits?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.movieCredits = JsonSerializer.Deserialize<MovieCredits>(Data);
            }
            else {
                Data = null;
            }
        } // GetMovieCast()

        public async Task GetTvCast(string tvID) {
            ClearHeaders();

            // Gets cast and crew for a movie
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/tv/" +
                    tvID + "/credits?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.tvCredits = JsonSerializer.Deserialize<TvCredits>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetMovieVideos(string movieID) {
            ClearHeaders();

            // Gets cast and crew 
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" +
                    movieID + "/videos?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.movieVideoSet = JsonSerializer.Deserialize<MovieVideoSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetTvVideos(string tvID) {
            ClearHeaders();

            // Gets cast and crew 
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/tv/" +
                    tvID + "/videos?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.tvVideoSet = JsonSerializer.Deserialize<TvVideoSet>(Data);
            }
            else {
                Data = null;
            }
        }

        public async Task GetTvActorDetails(string castID) {
            ClearHeaders();

             HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" + castID +
                    "?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.actor = JsonSerializer.Deserialize<Actor>(Data);
            }
            else {
                Data = null;
            }
        } 
        
        public async Task GetMovievActorDetails(string movieCastID) {
            ClearHeaders();

             HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/person/" + movieCastID +
                    "?api_key=" + API_KEY + "&language=en-US");

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.actor = JsonSerializer.Deserialize<Actor>(Data);
            }
            else {
                Data = null;
            }
        } 

        public void ClearHeaders() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "applicationException/json"));
        } // ClearHeaders()

    } // class
} // namespace