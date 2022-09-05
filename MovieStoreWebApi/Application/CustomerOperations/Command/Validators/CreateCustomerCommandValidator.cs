using FluentValidation;

namespace WebApi.Application.CustomerOperations.Command.Validators
{
  public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
  {
    public CreateCustomerCommandValidator()
    {
      RuleFor(command=> command.Model.Name).NotNull().NotEmpty();
      RuleFor(command=> command.Model.SurName).NotNull().NotEmpty();
      RuleFor(command => command.Model.Password).NotEmpty().NotNull();
      RuleFor(command => command.Model.Email).NotEmpty().NotNull().EmailAddress();
    }
  }
}