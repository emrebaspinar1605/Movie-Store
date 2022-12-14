using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Command;
using WebApi.Application.ActorOperations.Command.Validators;
using WebApi.Application.ActorOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class ActorController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public ActorController(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    
    [HttpGet]
    public IActionResult GetActor()
    {
      var query = new GetActorsQuery(_context,_mapper);
      var result = query.Handle();

      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetActor(int id)
    {
      var query = new GetActorsDetailQuery(_context,_mapper);
      query.Id = id;

      var result = query.Handle();

      return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateActor([FromBody] CreateActorModel model)
    {
      var command = new CreateActorCommand(_context,_mapper);
      command.Model = model;

      var validator = new CreateActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor([FromBody] UpdateActorModel model, int id)
    {
      var command = new UpdateActorCommand(_context);
      command.Model = model;
      command.Id = id;

      var validator = new UpdateActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
      var command = new DeleteActorCommand(_context);            
      command.Id = id;

      var validator = new DeleteActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}