using MovieStore.DbOperations;

namespace MovieStore.Application.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
	{
		private readonly IMovieStoreDbContext _context;

        public int MovieId { get; set; }

        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == MovieId);

            if(movie is null)
            {
                throw new InvalidOperationException("Film Bulunamadı.");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}

