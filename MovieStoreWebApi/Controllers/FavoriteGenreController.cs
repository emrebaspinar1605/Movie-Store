using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.FavoritesGenreOperations.Command.Validators;
using WebApi.App.FavoritesGenreOperations.Queries.Validators;
using WebApi.Application.FavoritesGenreOperations.Command;
using WebApi.Application.FavoritesGenreOperations.Command.Validators;
using WebApi.Application.FavoritesGenreOperations.Queries;
using WebApi.DbOperations;
using static WebApi.Application.FavoritesGenreOperations.Command.UpdateFavoriteGenresCommand;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class FavoriteGenreController : ControllerBase
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public FavoriteGenreController(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetFavoriteGenres()
    {
      var query = new GetFavoritesGenreQuery(_dbContext, _mapper);
      var response = query.Handle();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetFavoriteGenresDetail(int id)
    {
      var query = new GetFavoritesGenreDetailQuery(_dbContext, _mapper);
      query.Id = id;

      var validator = new GetFavoritesGenreDetailQueryValidator();
      validator.ValidateAndThrow(query);

      var response = query.Handle();

      return Ok(response);
    }
    [HttpPost]
    public IActionResult CreateFavoriteGenres([FromBody] FavoriteGenresModel model)
    {
      var command = new CreateFavoriteGenresCommand(_dbContext, _mapper);
      command.model = model;

      var validator = new CreateFavoriteGenresCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFavoriteGenres([FromBody] UpdateFavoriteGenresModel model, int Id)
    {
      var command = new UpdateFavoriteGenresCommand(_dbContext, _mapper);
      command.model = model;
      command.Id = Id;

      var validator = new UpdateFavoriteGenresCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFavoriteGenres(int Id)
    {
      var command = new DeleteFavoriteGenresCommand(_dbContext);        
      command.Id = Id;

      var validator = new DeleteFavoriteGenresCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}