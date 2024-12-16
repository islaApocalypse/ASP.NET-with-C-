using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CinemaConnoissuer2021.Models;

namespace CinemaConnoissuer2021.Pages {
     public class IndexModel : PageModel {

        // tv Search:
        public List<string> posterURLs = new List<string>();
        public List<string> overviews = new List<string>();
        public List<string> tvIDs = new List<string>();
        public int MAX_TV_RESULTS = 0;

        // TV show details:
        public string TvTitle = "";
        public string TvTagline = "";
        public string TvHomepage = "";
        public int numOfEpisodes;
        public int numOfSeasons;
        public string TvBackdropPath = "";
        public string TvFullsizedPoster = "";
        public string TvReleaseDate = "";
        public string TvOverview = "";

        // Tv Cast:
        public List<string> castNames = new List<string>();
        public List<string> castIDs = new List<string>();
        public List<string> castPics = new List<string>();

        // Tv Videos:
        public List<string> videoIDs = new List<string>();
        public int MAX_VIDEO_COUNT = 0;



        // movie Search:
        public List<string> moviePosterURLs = new List<string>();
        public List<string> movieOverviews = new List<string>();
        public List<string> movieIDs = new List<string>();
        public int MAX_MOVIE_RESULTS = 0;

        // Movie Details:
        public string movieTitle = "";
        public string movieTagline = "";
        public string movieHomepage = "";
        public int movieBudget;
        public long movieRevenue;
        public string movieBackdropPath = "";
        public string movieFullsizedPoster = "";
        public string movieReleaseDate = "";
        public string movieOverview = "";

        // movie Cast:
        public List<string> movieCastNames = new List<string>();
        public List<string> movieCastIDs = new List<string>();
        public List<string> movieCastPics = new List<string>();

        // movie Videos:
        public List<string> movieVideoIDs = new List<string>();
        public int MAX_MOVIE_VIDEO_COUNT = 0;


        public async Task OnGet() {
            await Program.fetch.TrendingTv();
            foreach(TvPoster t in Program.trendingTvSet.results) {
                posterURLs.Add(t.poster_path);
                overviews.Add(t.overview);
                tvIDs.Add(t.id.ToString());
            }
            if(Program.trendingTvSet.results.Count >= 10) {
                MAX_TV_RESULTS = 10;
            }
            else {
                MAX_TV_RESULTS = Program.trendingTvSet.results.Count;
            }
            await Program.fetch.TrendingMovie();
            foreach(MoviePoster m in Program.trendingMovieSet.results) {
                moviePosterURLs.Add(m.poster_path);
                movieOverviews.Add(m.overview);
                movieIDs.Add(m.id.ToString());
            }
            if(Program.trendingMovieSet.results.Count >= 10) {
                MAX_MOVIE_RESULTS = 10;
            }
            else {
                MAX_MOVIE_RESULTS = Program.trendingMovieSet.results.Count;
            }
        } // OnGet()

        public async Task OnPostTvSearch(string search) {
            await Program.fetch.TvSearch(search);
            foreach(TvPoster p in Program.tvSet.results) {
                posterURLs.Add(p.poster_path);
                overviews.Add(p.overview);
                tvIDs.Add(p.id.ToString());
            }
            if(Program.tvSet.results.Count >= 10)
                MAX_TV_RESULTS = 10;
            else
                MAX_TV_RESULTS = Program.tvSet.results.Count;
        } // OnPostTvSearch()
        
        public async Task OnPostMovieSearch(string search) {
            await Program.fetch.MovieSearch(search);
            foreach(MoviePoster moviePoster in Program.movieSet.results) {
                moviePosterURLs.Add(moviePoster.poster_path);
                movieOverviews.Add(moviePoster.overview);
                movieIDs.Add(moviePoster.id.ToString());
            }
            if(Program.movieSet.results.Count >= 10)
                MAX_MOVIE_RESULTS = 10;
            else
                MAX_MOVIE_RESULTS = Program.movieSet.results.Count;
        } // OnPostSearch()

        public async Task OnPostGetTvDetails(string tvID) {
            await Program.fetch.GetTvDetails(tvID);
            TvTitle = Program.tvShow.name;
            TvTagline = Program.tvShow.tagline;
            TvHomepage = Program.tvShow.homepage;
            numOfSeasons = Program.tvShow.number_of_seasons;
            numOfEpisodes = Program.tvShow.number_of_episodes;
            TvBackdropPath = Program.tvShow.backdrop_path;
            TvFullsizedPoster = Program.tvShow.poster_path;
            TvReleaseDate = Program.tvShow.first_air_date;
            TvOverview = Program.tvShow.overview;
            await OnPostGetTvCast(tvID);
            await OnPostGetTvVideos(tvID);
        }

        public async Task OnPostGetMovieDetails(string movieID) {
            await Program.fetch.GetMovieDetails(movieID);
            movieTitle = Program.movie.title;
            movieTagline = Program.movie.tagline;
            movieHomepage = Program.movie.homepage;
            movieBudget = Program.movie.budget;
            movieRevenue = Program.movie.revenue;
            movieBackdropPath = Program.movie.backdrop_path;
            movieFullsizedPoster = Program.movie.poster_path;
            movieReleaseDate = Program.movie.release_date;
            movieOverview = Program.movie.overview;
            await OnPostGetMovieCast(movieID);
            await OnPostGetMovieVideos(movieID);
        }

        public async Task OnPostGetTvCast(string tvID) {
            await Program.fetch.GetTvCast(tvID);
            foreach(TvCast cast in Program.tvCredits.cast){
                castNames.Add(cast.name);
                castIDs.Add(cast.id.ToString());
                castPics.Add(cast.profile_path);
            }
        } // GetTvCast()

        public async Task OnPostGetMovieCast(string movieID) {
            await Program.fetch.GetMovieCast(movieID);
            foreach(MovieCast cast in Program.movieCredits.cast){
                movieCastNames.Add(cast.name);
                movieCastIDs.Add(cast.id.ToString());
                movieCastPics.Add(cast.profile_path);
            }
        } // GetMovieCast()

        public async Task OnPostGetTvVideos(string tvID) {
            await Program.fetch.GetTvVideos(tvID);
            foreach (TvVideo video in Program.tvVideoSet.results) {
                videoIDs.Add(video.key);
            }
            if(videoIDs.Count >= 1)
                MAX_VIDEO_COUNT = 1;
            else
                MAX_VIDEO_COUNT = Program.tvSet.results.Count;
        } // OnPostGetTvVideos()

        public async Task OnPostGetMovieVideos(string movieID) {
            await Program.fetch.GetMovieVideos(movieID);
            foreach (MovieVideo video in Program.movieVideoSet.results) {
                movieVideoIDs.Add(video.key);
            }
            if(movieVideoIDs.Count >= 1)
                MAX_MOVIE_VIDEO_COUNT = 1;
            else
                MAX_MOVIE_VIDEO_COUNT = Program.movieSet.results.Count;
        } // OnPostGetMovieVideos(()

        public void OnPostGetTvActorDetails(string castID) {
            Response.Redirect("./Actor?id=" + castID);
        } // OnPostGetTvActorDetails()

        public void OnPostGetMovieActorDetails(string movieCastID) {
            Response.Redirect("./Actor?id=" + movieCastID);
        } // OnPostGetMovieActorDetails()

    } // class // class
} // namespace