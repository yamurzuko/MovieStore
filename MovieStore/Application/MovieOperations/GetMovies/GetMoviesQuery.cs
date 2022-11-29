using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.GetMovies
{
    public class GetMoviesQuery
	{
		private readonly IMovieStoreDbContext _context;

		private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _context.Movies.Include(x => x.Genre).OrderBy(x => x.Id).ToList<Movie>();

            List<MoviesViewModel> model = _mapper.Map<List<MoviesViewModel>>(movieList);

            return model;
        }

        public class MoviesViewModel
        {
            public string MovieName { get; set; }

            public string Genre { get; set; }

            public int Price { get; set; }
        }
    }
}

