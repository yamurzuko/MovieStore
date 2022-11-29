using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
	{

        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

