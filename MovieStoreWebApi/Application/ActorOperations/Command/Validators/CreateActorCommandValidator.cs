using FluentValidation;

namespace WebApi.Application.ActorOperations.Command.Validators
{
  public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
  {
    public CreateActorCommandValidator()
    {
      RuleFor(command=> command.Model.Name).NotNull().NotEmpty();
      RuleFor(command=> command.Model.SurName).NotNull().NotEmpty();
    }
  }
}