using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
	{
        public CreateMovieModel Model { get; set; }

		private readonly IMovieStoreDbContext _context;

		private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);

            if(movie is not null)
            {
                throw new InvalidOperationException("Film Zaten Mevcut");
            }

            movie = _mapper.Map<Movie>(Model);

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public class CreateMovieModel
        {
            public string MovieName { get; set; }

            public DateTime MovieYear { get; set; }

            public int GenreId { get; set; }

            public int Price { get; set; }
        }
    }
}

