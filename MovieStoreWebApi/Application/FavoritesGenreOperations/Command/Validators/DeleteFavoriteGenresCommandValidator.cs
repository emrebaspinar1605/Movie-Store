using FluentValidation;
using WebApi.Application.FavoritesGenreOperations.Command;

namespace WebApi.Application.FavoritesGenreOperations.Command.Validators
{
  public class DeleteFavoriteGenresCommandValidator : AbstractValidator<DeleteFavoriteGenresCommand>
  {
    public DeleteFavoriteGenresCommandValidator()
    {
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}