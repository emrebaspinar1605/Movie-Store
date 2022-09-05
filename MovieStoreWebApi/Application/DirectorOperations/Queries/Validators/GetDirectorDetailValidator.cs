using FluentValidation;

namespace WebApi.Application.DirectorOperations.Queries.Validators
{
  public class GetDirectorDetailValidator : AbstractValidator<GetDirectorQueryDetail>
  {
    public GetDirectorDetailValidator()
    {
      RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}