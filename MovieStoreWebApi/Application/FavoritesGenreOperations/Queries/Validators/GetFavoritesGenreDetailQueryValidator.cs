using FluentValidation;
using WebApi.Application.FavoritesGenreOperations.Queries;

namespace WebApi.App.FavoritesGenreOperations.Queries.Validators
{
    public class GetFavoritesGenreDetailQueryValidator : AbstractValidator<GetFavoritesGenreDetailQuery>
    {
        public GetFavoritesGenreDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}