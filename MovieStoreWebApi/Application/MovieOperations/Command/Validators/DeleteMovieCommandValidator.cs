using FluentValidation;
using WebApi.Application.MovieOperations.Command;

namespace WebApi.Application.MovieOperations.Command.Validators
{
  public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
  {
    public DeleteMovieCommandValidator()
    {
      RuleFor(command => command.Id).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}