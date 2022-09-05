using FluentValidation;

namespace WebApi.Application.DirectorMoviesOperations.Queries.Validators
{
  public class GetDirectorMovieDetailQueryValidator : AbstractValidator<GetDirectorMovieDetailQuery>
  {
    public GetDirectorMovieDetailQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}