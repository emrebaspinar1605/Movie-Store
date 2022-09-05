using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorMoviesOperations.Command;
using WebApi.Application.DirectorMoviesOperations.Command.Validators;
using WebApi.Application.DirectorMoviesOperations.Queries;
using WebApi.Application.DirectorMoviesOperations.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class DirectorMovieController : ControllerBase
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public DirectorMovieController(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetActorMovie()
    {
      var query = new GetDirectorMoviesQuery(_dbContext, _mapper);
      var response = query.Handle();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetActorMovie(int id)
    {
      var query = new GetDirectorMovieDetailQuery(_dbContext, _mapper);
      query.Id = id;

      var validator = new GetDirectorMovieDetailQueryValidator();
      validator.ValidateAndThrow(query);

      var response = query.Handle();

      return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateDirectorMovie([FromBody] DirectorMovieModel model)
    {
      var command = new CreateDirectorMovieCommand(_dbContext, _mapper);
      command.model = model;

      var validator = new CreateDirectorMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirectorMovie([FromBody] DirectorMovieModel model, int Id)
    {
      var command = new UpdateDirectorMovieCommand(_dbContext, _mapper);
      command.model = model;
      command.Id = Id;

      var validator = new UpdateDirectorMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirectorMovie(int Id)
    {
      var command = new DeleteDirectorMovieCommand(_dbContext);        
      command.Id = Id;

      var validator = new DeleteDirectorMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}