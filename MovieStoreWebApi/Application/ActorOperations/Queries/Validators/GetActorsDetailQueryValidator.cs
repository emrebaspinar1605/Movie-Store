using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries.Validators
{
 public class GetActorsDetailQueryValidator : AbstractValidator<GetActorsDetailQuery>
  {
    public GetActorsDetailQueryValidator()
    {
      RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}