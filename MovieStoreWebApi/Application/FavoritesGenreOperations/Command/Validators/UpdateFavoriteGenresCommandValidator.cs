using FluentValidation;
using WebApi.Application.FavoritesGenreOperations.Command;

namespace WebApi.App.FavoritesGenreOperations.Command.Validators
{
  public class UpdateFavoriteGenresCommandValidator : AbstractValidator<UpdateFavoriteGenresCommand>
  {
    public UpdateFavoriteGenresCommandValidator()
    {
      RuleFor(command=> command.model.FavoritesGenreId).GreaterThan(0).NotNull().NotEmpty();
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}