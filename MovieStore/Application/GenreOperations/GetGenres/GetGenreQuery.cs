using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.Application.GenreOperations.GetGenres
{
    public class GetGenreQuery
	{
		private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public GetGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);

            List<GenreViewModel> genreList = _mapper.Map<List<GenreViewModel>>(genres);
            return genreList;
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

