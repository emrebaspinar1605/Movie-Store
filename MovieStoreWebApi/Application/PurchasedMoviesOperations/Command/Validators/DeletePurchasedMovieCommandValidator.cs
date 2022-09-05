using FluentValidation;

namespace WebApi.Application.PurchasedMoviesOperations.Command.Validator
{
  public class DeletePurchasedMovieCommandValidator : AbstractValidator<DeletePurchasedMovieCommand>
  {
    public DeletePurchasedMovieCommandValidator()
    {
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}