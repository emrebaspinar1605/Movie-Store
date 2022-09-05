using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorMoviesOperation.Command;
using WebApi.Application.ActorMoviesOperation.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class ActorMovieController : ControllerBase
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public ActorMovieController(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetActorMovie()
    {
      var query = new GetActorMoviesQuery(_dbContext, _mapper);
      var response = query.Handle();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetActorMovie(int id)
    {
      var query = new GetActorMoviesDetailQuery(_dbContext, _mapper);
      query.Id = id;

      var validator = new GetActorMoviesDetailQueryValidator();
      validator.ValidateAndThrow(query);

      var response = query.Handle();

      return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateActorMovie([FromBody] CreateActorMovieModel model)
    {
      var command = new CreateActorMoviesCommand(_dbContext, _mapper);
      command.model = model;

      var validator = new CreateActorMoviesCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActorMovie([FromBody] UpdateActorMovieModel model, int Id)
    {
      var command = new UpdateActorMovieCommand(_dbContext, _mapper);
      command.model = model;
      command.Id = Id;

      var validator = new UpdateActorMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActorMovie(int Id)
    {
      var command = new DeleteActorMovieCommand(_dbContext);        
      command.Id = Id;

      var validator = new DeleteActorMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}