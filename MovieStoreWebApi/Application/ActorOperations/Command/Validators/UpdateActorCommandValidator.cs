using FluentValidation;

namespace WebApi.Application.ActorOperations.Command.Validators
{
  public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
  {
    public UpdateActorCommandValidator()
    {
      RuleFor(command => command.Id).GreaterThan(0);
      RuleFor(command => command.Model.Name).NotEmpty().NotNull();
      RuleFor(command => command.Model.SurName).NotEmpty().NotNull();
    }
  }
}