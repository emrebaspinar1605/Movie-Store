using FluentValidation;

namespace WebApi.Application.DirectorOperations.Command.Validators
{
  public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
  {
    public DeleteDirectorCommandValidator()
    {
      RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}