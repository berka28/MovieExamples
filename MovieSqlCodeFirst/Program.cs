using MovieSqlCodeFirst.Services;
using System;
using System.Threading.Tasks;

namespace MovieSqlCodeFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AddMovieAsync("MovieTime!");
        }

        private static async Task AddMovieAsync(string name)
        {
            await MovieService.AddMovieAsync(name);
            Console.WriteLine("Created new Movie in the Database");
        }
    }
}
