using FluentValidation;

namespace MovieStore.Application.MovieOperations.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
	{
		public CreateMovieCommandValidator()
		{
			RuleFor(command => command.Model.MovieName).MinimumLength(4);
			RuleFor(command => command.Model.MovieYear.Date).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
        }
    }
}

