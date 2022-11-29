using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.GenreOperations.CreateGenres;
using MovieStore.Application.GenreOperations.DeleteGenres;
using MovieStore.Application.GenreOperations.GetGenres;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class GenreController : ControllerBase
	{
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult CreateGenre([FromBody] CreateGenreModel genreModel)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);

            command.Model = genreModel;

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            command.genreId = id;

            command.Handle();
            return Ok();
        }

        [HttpGet]

        public IActionResult GetGenre()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }
    }
}

