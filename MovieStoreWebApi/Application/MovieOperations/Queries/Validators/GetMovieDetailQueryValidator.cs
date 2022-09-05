using FluentValidation;
using WebApi.Application.MovieOperations.Queries;

namespace WebApi.Application.MovieOperations.Queries.Validators
{
  public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
  {
    public GetMovieDetailQueryValidator()
    {
      RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}