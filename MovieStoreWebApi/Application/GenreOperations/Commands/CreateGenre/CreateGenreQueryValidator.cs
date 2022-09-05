using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
  public class CreateGenreQueryValidator : AbstractValidator<CreateGenreQuery>
  {
    public CreateGenreQueryValidator()
    {
      RuleFor(g => g.Model.Name).NotEmpty().MinimumLength(3);
    }
  }
}