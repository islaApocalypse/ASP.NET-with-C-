using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using CinemaConnoissuer2021.Models;

namespace CinemaConnoissuer2021 {
    public class Program {
        
        public static Fetch fetch = new Fetch();
        public static Actor actor = new Actor();
        public static TrendingTvSet trendingTvSet = new TrendingTvSet();
        public static TrendingMovieSet trendingMovieSet = new TrendingMovieSet();
        public static TvSet tvSet = new TvSet();
        public static TvShow tvShow = new TvShow();
        public static TvCredits tvCredits = new TvCredits();
        public static TvVideoSet tvVideoSet = new TvVideoSet();
        public static MovieSet movieSet = new MovieSet();
        public static Movie movie = new Movie();
        public static MovieCredits movieCredits = new MovieCredits();
        public static MovieVideoSet movieVideoSet = new MovieVideoSet();

        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
                
    } // class
} // namespace