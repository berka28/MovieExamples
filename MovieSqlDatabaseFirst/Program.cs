using MovieSqlDatabaseFirst.Services;
using System;
using System.Threading.Tasks;

namespace MovieSqlDatabaseFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AddMovieAsync();
            await ListAllMoviesAsync();
            await GetMovieAsync();
            await GetMoviesByWatchedAsync(true);
            await MarkMovieAsWatchedAsync();
            await RemoveMovieAsync();

        }

        private static async Task AddMovieAsync()
        {
            Console.WriteLine("Enter a new Movie: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a genre: ");
            string genre = Console.ReadLine();

            await MovieService.AddMovieAsync(name, genre);
            Console.WriteLine("Created new Movie in the Database");
        }

        private static async Task ListAllMoviesAsync()
        {
            var movies = await MovieService.GetMoviesAsync();

            Console.WriteLine("Listing all Movies in the Database");
            foreach (var movie in movies)
            {
                Console.WriteLine($"EAN: {movie.Ean}");
                Console.WriteLine($"Name: {movie.Name}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Watched: {movie.Watched}");
                Console.WriteLine($"Bought: {movie.Bought}");
                Console.WriteLine(new string('-', 30));

            }
        }

        private static async Task GetMovieAsync(int EAN = 0)
        {
            if (EAN == 0)
            {
                Console.WriteLine("Enter EAN of the Movie: ");
                EAN = Convert.ToInt32(Console.ReadLine());
            }

            var movie = await MovieService.GetMovieAsync(EAN);
            Console.WriteLine($"EAN: {movie.Ean}");
            Console.WriteLine($"Name: {movie.Name}");
            Console.WriteLine($"Genre: {movie.Genre}");
            Console.WriteLine($"Watched: {movie.Watched}");
            Console.WriteLine($"Bought: {movie.Bought}");
        }

        private static async Task GetMoviesByWatchedAsync(bool watched)
        {
            var movies = await MovieService.GetMoviesByWatchedAsync(watched);

            Console.WriteLine("Listing Movies in the Database");
            foreach (var movie in movies)
            {
                Console.WriteLine($"EAN: {movie.Ean}");
                Console.WriteLine($"Name: {movie.Name}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Watched: {movie.Watched}");
                Console.WriteLine($"Bought: {movie.Bought}");
                Console.WriteLine(new string('-', 30));

            }
        }

        private static async Task MarkMovieAsWatchedAsync()
        {
            Console.WriteLine("Enter EAN of the watched Movie: ");
            int EAN = Convert.ToInt32(Console.ReadLine());

            await MovieService.UpdateMovieAsync(EAN);
            await GetMovieAsync(EAN);
        }

        private static async Task RemoveMovieAsync()
        {
            Console.WriteLine("Enter EAN for the Movie to remove: ");
            int EAN = Convert.ToInt32(Console.ReadLine());

            await MovieService.RemoveMovieAsync(EAN);
            await ListAllMoviesAsync();
        }
    }
}
