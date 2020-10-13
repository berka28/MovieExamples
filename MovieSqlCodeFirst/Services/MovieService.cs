using MovieSqlCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieSqlCodeFirst.Services
{
    public static class MovieService
    {
        public static async Task AddMovieAsync(string name)
        {
            using MovieContext context = new MovieContext();

            context.Movies.Add(new Movie(name));
            await context.SaveChangesAsync();

        }

    }
}
