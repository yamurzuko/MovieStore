using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public interface IMovieStoreDbContext
	{
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }
}

