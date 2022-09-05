using FluentValidation;

namespace WebApi.Application.ActorMoviesOperation.Queries
{
    public class GetActorMoviesDetailQueryValidator : AbstractValidator<GetActorMoviesDetailQuery>
    {
        public GetActorMoviesDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}