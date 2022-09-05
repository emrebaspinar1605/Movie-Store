using FluentValidation;

namespace WebApi.Application.ActorOperations.Command.Validators
{
  public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
  {
    public DeleteActorCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
    }
  }
  
}