using System;
using FluentValidation;
using WebApi.Application.MovieOperations.Command;

namespace WebApi.Application.MovieOperations.Command.Validators
{
  public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
  {
    public CreateMovieCommandValidator()
    {
      RuleFor(command => command.Model.Name).NotEqual("string").MaximumLength(30).NotEmpty().NotNull();
      RuleFor(command => command.Model.GenreId).GreaterThan(0).NotEmpty().NotNull();
      RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now.Date).NotEmpty().NotNull();
      RuleFor(command => command.Model.Price).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}