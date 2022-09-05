using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
  public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
  {
    public GetGenreDetailQueryValidator()
    {
      RuleFor(g => g.GenreId).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}