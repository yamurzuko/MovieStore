using MovieStore.DbOperations;

namespace MovieStore.Application.GenreOperations.DeleteGenres
{
    public class DeleteGenreCommand
	{
        public int genreId { get; set; }

		private readonly IMovieStoreDbContext _context;

        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == genreId);

            if(genre == null)
            {
                throw new InvalidOperationException("Genre Mevcut Değil");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}

