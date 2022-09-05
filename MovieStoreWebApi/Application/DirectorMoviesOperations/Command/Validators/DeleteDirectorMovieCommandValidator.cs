using FluentValidation;

namespace WebApi.Application.DirectorMoviesOperations.Command.Validators
{
  public class DeleteDirectorMovieCommandValidator : AbstractValidator<DeleteDirectorMovieCommand>
  {
    public DeleteDirectorMovieCommandValidator()
    {            
      RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
    }
  }
}