using FluentValidation;

namespace WebApi.Application.ActorMoviesOperation.Command
{
  public class CreateActorMoviesCommandValidator : AbstractValidator<CreateActorMoviesCommand>
  {
    public CreateActorMoviesCommandValidator()
    {
      RuleFor(command=> command.model.ActorId).GreaterThan(0).NotNull().NotEmpty();
      RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}