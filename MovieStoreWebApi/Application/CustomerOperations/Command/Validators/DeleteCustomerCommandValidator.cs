using FluentValidation;

namespace WebApi.Application.CustomerOperations.Command.Validators
{
  public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}