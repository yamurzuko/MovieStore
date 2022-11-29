using System;
using MovieStore.DbOperations;

namespace MovieStore.Application.MovieOperations.UpdateMovie
{
	public class UpdateMovieCommand
	{
		private readonly IMovieStoreDbContext _context;

		public int MovieId { get; set; }

		public UpdateMovieModel Model { get; set; }

		public UpdateMovieCommand(IMovieStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);

			if(movie == null)
			{
				throw new InvalidOperationException("Film bulunamadı.");
			}

			movie.MovieName = Model.MovieName != default ? Model.MovieName : movie.MovieName;
			movie.Price = Model.Price != default ? Model.Price : movie.Price;

			_context.SaveChanges();
		}
	}

	public class UpdateMovieModel
	{
		public string MovieName { get; set; }

		public int Price { get; set; }
	}
}

