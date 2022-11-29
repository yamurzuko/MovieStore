using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Genres.AddRange(

                    new Genre
                    {
                        Name = "Personal Growt"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                 );

                context.Movies.AddRange(

                    new Movie
                    {
                        MovieName = "Lean Startup",
                        MovieYear = new DateTime(1997, 05, 24),
                        GenreId = 1,
                        Price = 100
                    },
                    new Movie
                    {
                        MovieName = "Healand",
                        MovieYear = new DateTime(2002, 09, 12),
                        GenreId = 3,
                        Price = 50
                    },
                    new Movie
                    {
                        MovieName = "Dune",
                        MovieYear = new DateTime(2001, 12, 21),
                        GenreId = 2,
                        Price = 150
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

