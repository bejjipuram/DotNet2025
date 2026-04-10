using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAP2025.Day_20
{
    public class Movie
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Ratings { get; set; }
    }
    public class MovieMain
    {
        public static List<Movie> MovieList;    
        public static void AddMovie(string MovieDetails)
        {
            string[] data = MovieDetails.Split(',');
            Movie movie = new Movie()
            {
                Title = data[0],
                Artist = data[1],
                Genre = data[2],
                Ratings = int.Parse(data[3])
            };
            MovieList.Add(movie);

        }
        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            List<Movie> result = MovieList.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            return result;

        }
        public static List<Movie> ViewMoviesByRatings()
        {
            return MovieList.OrderBy(m => m.Ratings).ToList();
        }

        public static void Main(string[] args)
        {
            MovieList = new List<Movie>();
            Console.WriteLine("Enter number of Movies: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Movie Dtails(1.Title, 2.Artist, 3.Genre, 4.Ratings): ");
            for(int i = 0; i < n; i++)
            {
                string details = Console.ReadLine();
                AddMovie(details);
            }
            Console.WriteLine("Enter the Genre to search: ");
            string genre = Console.ReadLine();
            List<Movie> genreMovies = ViewMoviesByGenre(genre);
            if (genreMovies.Count == 0)
            {
                Console.WriteLine("No Movies have been found in the genre: " + genre);
            }
            else
            {
                Console.WriteLine("Movies given in genre: ");
                foreach(var movie in genreMovies)
                {
                    Console.WriteLine($"{movie.Title}, {movie.Artist}, {movie.Genre}, {movie.Ratings}");
                }
            }
            Console.WriteLine("\nMovies Sorted by Ratings: ");
            List<Movie> sortedMovies = ViewMoviesByRatings();
            foreach(var movie in sortedMovies)
            {
                Console.WriteLine($"{movie.Title}, {movie.Artist}, {movie.Genre}, {movie.Ratings}");
            }
        }
    }
}
