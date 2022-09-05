using FluentValidation;

namespace WebApi.Application.PurchasedMoviesOperations.Command.Validator
{
  public class CreatePurchaseMovieCommandValidator : AbstractValidator<CreatePurchaseMovieCommand>
  {
    public CreatePurchaseMovieCommandValidator()
    {
      RuleFor(command=> command.model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
      RuleFor(command=> command.model.MovieId).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}