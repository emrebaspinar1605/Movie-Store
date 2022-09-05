using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.FavoritesGenreOperations.Command.Validators;
using WebApi.App.FavoritesGenreOperations.Queries.Validators;
using WebApi.Application.DirectorMoviesOperations.Command;
using WebApi.Application.DirectorMoviesOperations.Command.Validators;
using WebApi.Application.DirectorMoviesOperations.Queries;
using WebApi.Application.DirectorMoviesOperations.Queries.Validators;
using WebApi.Application.DirectorOperations.Command;
using WebApi.Application.DirectorOperations.Command.Validators;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.DirectorOperations.Queries.Validators;
using WebApi.Application.FavoritesGenreOperations.Command;
using WebApi.Application.FavoritesGenreOperations.Command.Validators;
using WebApi.Application.FavoritesGenreOperations.Queries;
using WebApi.Application.MovieOperations.Command;
using WebApi.Application.MovieOperations.Command.Validators;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Application.MovieOperations.Queries.Validators;
using WebApi.Application.PurchasedMoviesOperations.Command;
using WebApi.Application.PurchasedMoviesOperations.Command.Validator;
using WebApi.Application.PurchasedMoviesOperations.Command.Validators;
using WebApi.Application.PurchasedMoviesOperations.Queries.Validators;
using WebApi.DbOperations;
using static WebApi.Application.FavoritesGenreOperations.Command.UpdateFavoriteGenresCommand;

namespace WebApi.Controllers

{
  [Authorize]
  [Route("[controller]s")]
  [ApiController]
  public class DirectorController : ControllerBase
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public DirectorController(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var query = new GetDirectorQuery(_dbContext, _mapper);
      var result = query.Handle();

      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var query = new GetDirectorQueryDetail(_dbContext, _mapper);
      query.Id = id;

      var validator = new GetDirectorDetailValidator();
      validator.ValidateAndThrow(query);

      var result = query.Handle();

      return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateDirector([FromBody] DirectorModel model)
    {
      var command = new CreateDirectorCommand(_dbContext, _mapper);
      command.model = model;

      var validator = new CreateDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector([FromBody] DirectorModel model, int id)
    {
      var command = new UpdateDirectorCommand(_dbContext, _mapper);
      command.model = model;
      command.Id = id;

      var validator = new UpdateDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirector(int id)
    {
      var command = new DeleteDirectorCommand(_dbContext);
      command.Id = id;

      var validator = new DeleteDirectorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}