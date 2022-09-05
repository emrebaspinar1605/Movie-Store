using FluentValidation;
using WebApi.Application.PurchasedMoviesOperations.Command.Validators;

namespace WebApi.Application.PurchasedMoviesOperations.Queries.Validators
{
  public class GetPurchasedMoviesDetailQueryValidator : AbstractValidator<GetPurchasedMoviesDetailQuery>
  {
    public GetPurchasedMoviesDetailQueryValidator()
    {
      RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}