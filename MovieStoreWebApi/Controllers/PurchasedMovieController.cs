using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.PurchasedMoviesOperations.Command;
using WebApi.Application.PurchasedMoviesOperations.Command.Validator;
using WebApi.Application.PurchasedMoviesOperations.Command.Validators;
using WebApi.Application.PurchasedMoviesOperations.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class PurchasedMovieController : ControllerBase
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public PurchasedMovieController(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPurchasedMovies()
    {
      var query = new GetPurchasedMoviesQuery(_dbContext, _mapper);
      var response = query.Handle();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetPurchasedMoviesDetail(int id)
    {
      var query = new GetPurchasedMoviesDetailQuery(_dbContext, _mapper);
      query.Id = id;

      var validator = new GetPurchasedMoviesDetailQueryValidator();
      validator.ValidateAndThrow(query);

      var response = query.Handle();

      return Ok(response);
    }
    [HttpPost]
    public IActionResult CreatePurchasedMovie([FromBody] PurchasedMoviesModel model)
    {
      var command = new CreatePurchaseMovieCommand(_dbContext, _mapper);
      command.model = model;

      var validator = new CreatePurchaseMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdatePurchasedMovie([FromBody] PurchasedMoviesModel model, int Id)
    {
      var command = new UpdatePurchaseMovieCommand(_dbContext, _mapper);
      command.model = model;
      command.Id = Id;

      var validator = new UpdatePurchaseMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteDirectorMovie(int Id)
    {
      var command = new DeletePurchasedMovieCommand(_dbContext);        
      command.Id = Id;

      var validator = new DeletePurchasedMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }
  }
}