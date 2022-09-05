using FluentValidation;

namespace WebApi.Application.ActorMoviesOperation.Command
{
  public class DeleteActorMovieCommandValidator : AbstractValidator<DeleteActorMovieCommand>
  {
    public DeleteActorMovieCommandValidator()
    {            
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}