using AutoMapper;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.CreateMovie.CreateMovieCommand;
using static MovieStore.Application.MovieOperations.GetMovies.GetMoviesQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateMovieModel, Movie>();
			CreateMap<Movie, MoviesViewModel>()
				.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

        }
	}
}

