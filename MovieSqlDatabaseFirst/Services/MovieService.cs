using Microsoft.EntityFrameworkCore;
using MovieSqlDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSqlDatabaseFirst.Services
{
    public static class MovieService
    {
        public static async Task AddMovieAsync(string name, string genre)
        {
            using MovieContext context = new MovieContext();

            context.Movies.Add(new Movie(name, genre));
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            using MovieContext context = new MovieContext();

            return await context.Movies.ToListAsync();
        }

        public static async Task<Movie> GetMovieAsync(int EAN)
        {
            using MovieContext context = new MovieContext();

            return await context.Movies.FindAsync(EAN);
        }

        public static async Task<IEnumerable<Movie>> GetMoviesByWatchedAsync(bool watched)
        {
            using MovieContext context = new MovieContext();

            return await context.Movies.Where(movie => movie.Watched == watched).ToListAsync();
        }

        public static async Task UpdateMovieAsync(int EAN)
        {
            using MovieContext context = new MovieContext();

            var movie = await context.Movies.FindAsync(EAN);

            if (movie != null)
            {
                movie.Watched = true;
                context.Entry(movie).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveMovieAsync(int EAN)
        {
            using MovieContext context = new MovieContext();

            var movie = await context.Movies.FindAsync(EAN);

            if (movie != null)
            {
                context.Movies.Remove(movie);
                await context.SaveChangesAsync();
            }
        }

    }
}
