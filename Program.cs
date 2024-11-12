using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase
{
    // Represents a Movie with title, category, runtime, and year of release
    public class Movie
    {
        public string Title { get; set; }       // Movie title
        public string Category { get; set; }    // Movie category (e.g., drama, scifi)
        public int Runtime { get; set; }        // Runtime in minutes
        public int YearReleased { get; set; }   // Year of release

        // Constructor to initialize the movie's properties
        public Movie(string title, string category, int runtime, int yearReleased)
        {
            Title = title;
            Category = category.ToLower();  // Store category in lowercase for easier matching
            Runtime = runtime;
            YearReleased = yearReleased;
        }
    }

    // Manages the movie list and interactions with the user
    public class MovieApp
    {
        private List<Movie> movies;  // List to store all movies

        public MovieApp()
        {
            // Initialize list of movies with various categories and details
            movies = new List<Movie>
            {
                new Movie("The Lion King", "animated", 88, 1994),
                new Movie("Toy Story", "animated", 81, 1995),
                new Movie("Inception", "scifi", 148, 2010),
                new Movie("Interstellar", "scifi", 169, 2014),
                new Movie("The Conjuring", "horror", 112, 2013),
                new Movie("It", "horror", 135, 2017),
                new Movie("The Godfather", "drama", 175, 1972),
                new Movie("Forrest Gump", "drama", 142, 1994),
                new Movie("Alien", "scifi", 117, 1979),
                new Movie("Shrek", "animated", 90, 2001)
            };
        }

        // Displays movies from the specified category, sorted alphabetically
        public void DisplayMoviesByCategory(string category)
        {
            var filteredMovies = movies
                .Where(m => m.Category == category.ToLower())
                .OrderBy(m => m.Title);

            if (filteredMovies.Any())
            {
                Console.WriteLine($"\nMovies in the {category} category:");
                foreach (var movie in filteredMovies)
                {
                    Console.WriteLine($"{movie.Title} ({movie.YearReleased}) - {movie.Runtime} mins");
                }
            }
            else
            {
                Console.WriteLine("No movies found in this category.");
            }
        }

        // Shows a numbered menu for category selection to the user
        public void ShowCategoryMenu()
        {
            Console.WriteLine("Categories:");
            Console.WriteLine("1. Animated");
            Console.WriteLine("2. Drama");
            Console.WriteLine("3. Horror");
            Console.WriteLine("4. Sci-Fi");
            Console.Write("Select a category by number: ");
        }

        // Main loop for running the application
        public void Run()
        {
            Console.WriteLine("Welcome to the Movie List Application!");
            bool continueApp = true;

            while (continueApp)
            {
                ShowCategoryMenu();
                string userChoice = Console.ReadLine()?.Trim();

                // Map user choice to categories
                string selectedCategory = userChoice switch
                {
                    "1" => "animated",
                    "2" => "drama",
                    "3" => "horror",
                    "4" => "scifi",
                    _ => null
                };

                if (selectedCategory != null)
                {
                    DisplayMoviesByCategory(selectedCategory);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid category number.");
                }

                // Prompt to continue or end the program
                Console.Write("\nWould you like to continue? (y/n): ");
                continueApp = Console.ReadLine()?.Trim().ToLower() == "y";
            }

            Console.WriteLine("Goodbye!");
        }
    }

    // Entry point to start the application
    class Program
    {
        static void Main()
        {
            var app = new MovieApp();
            app.Run();
        }
    }
}