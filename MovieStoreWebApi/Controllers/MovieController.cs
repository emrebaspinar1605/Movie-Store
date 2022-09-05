using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Command;
using WebApi.Application.MovieOperations.Command.Validators;
using WebApi.Application.MovieOperations.Queries;
using WebApi.Application.MovieOperations.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class MovieController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public MovieController(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetMovie()
    {
      var query = new GetMovieQuery(_context,_mapper);
      var response = query.Handle();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieDetail(int id)
    {
      var query = new GetMovieDetailQuery(_context,_mapper);
      query.Id = id;

      var validator = new GetMovieDetailQueryValidator();
      validator.ValidateAndThrow(query);
      
      var result = query.Handle();

      return Ok(result);
    }

    [HttpPost]
    public IActionResult CrateMovie([FromBody] CreateMovieModel model)
    {
      var command = new CreateMovieCommand(_context,_mapper);
      command.Model = model;

      var validator = new CreateMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie([FromBody] UpdateMovieModel model, int id)
    {
      var command = new UpdateMovieCommand(_context);
      command.Model = model;
      command.Id = id;

      var validator = new UpdateMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
      var command = new DeleteMovieCommand(_context);
      command.Id = id;

      var validator = new DeleteMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}