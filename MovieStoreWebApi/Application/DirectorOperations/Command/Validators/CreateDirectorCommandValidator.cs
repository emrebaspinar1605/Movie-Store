using FluentValidation;

namespace WebApi.Application.DirectorOperations.Command.Validators
{
  public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
  {
    public CreateDirectorCommandValidator()
    {
      RuleFor(command => command.model.Name).MinimumLength(1).NotNull().NotEmpty();
      RuleFor(command => command.model.SurName).MinimumLength(1).NotNull().NotEmpty();
    }
  }
}