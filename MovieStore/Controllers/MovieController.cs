using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.MovieOperations.CreateMovie;
using MovieStore.Application.MovieOperations.DeleteMovie;
using MovieStore.Application.MovieOperations.GetMovies;
using MovieStore.Application.MovieOperations.UpdateMovie;
using MovieStore.DbOperations;
using static MovieStore.Application.MovieOperations.CreateMovie.CreateMovieCommand;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
	{
		private readonly IMovieStoreDbContext _context;

		private readonly IMapper _mapper;

		public MovieController(IMovieStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]

		public IActionResult GetMovies()
		{
			GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);

			var result = query.Handle();
			return Ok(result);
		}

		[HttpPost]

		public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
		{
			CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
			CreateMovieCommandValidator validator = new CreateMovieCommandValidator();

			command.Model = newMovie;

			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteMovie(int id)
		{
			DeleteMovieCommand command = new DeleteMovieCommand(_context);
			DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();

			command.MovieId = id;

			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}

		[HttpPut("{id}")]

		public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel movieModel)
		{
			UpdateMovieCommand command = new UpdateMovieCommand(_context);
			UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();

			command.MovieId = id;
			command.Model = movieModel;

			validator.ValidateAndThrow(command);
			command.Handle();

			return Ok();
		}
	}
}

