using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.GenreOperations.CreateGenres
{
    public class CreateGenreCommand
	{
        public CreateGenreModel Model { get; set; }

		private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if(genre != null)
            {
                throw new InvalidOperationException("Genre Zaten Mevcut");
            }

            genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}

