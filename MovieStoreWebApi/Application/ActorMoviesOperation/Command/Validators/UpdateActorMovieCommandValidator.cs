using FluentValidation;

namespace WebApi.Application.ActorMoviesOperation.Command
{
  public class UpdateActorMovieCommandValidator : AbstractValidator<UpdateActorMovieCommand>
  {
    public UpdateActorMovieCommandValidator()
    {
      RuleFor(command=> command.model.ActorId).GreaterThan(0).NotNull().NotEmpty();
      RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}