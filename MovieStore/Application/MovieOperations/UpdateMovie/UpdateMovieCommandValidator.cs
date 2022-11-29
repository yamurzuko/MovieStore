using FluentValidation;

namespace MovieStore.Application.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
	{
		public UpdateMovieCommandValidator()
		{
			RuleFor(command => command.Model.MovieName).MinimumLength(4);
			RuleFor(command => command.Model.Price).GreaterThan(0);
		}
	}
}

