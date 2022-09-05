using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations.Command;
using WebApi.Application.CustomerOperations.Command.Validators;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.Application.CustomerOperations.TokenOperations;
using WebApi.DbOperations;

namespace WebApi.Controllers

{
  [ApiController]
  [Route("[controller]s")]
  public class CustomerController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;

    public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetCustomer()
    {
      var query = new GetCustomerQuery(_context, _mapper);
      var result = query.Handle();

      return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetCustomerDetail(int id)
    {
      var query = new GetCustomerQueryDetail(_context, _mapper);
      query.Id = id;

      var result = query.Handle();

      return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerModel model)
    {
      var command = new CreateCustomerCommand(_context, _mapper);
      command.Model = model;

      var validator = new CreateCustomerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer([FromBody] CustomerModel model, int id)
    {
      var command = new UpdateCustomerCommand(_context);
      command.Model = model;
      command.Id = id;

      var validator = new UpdateCustomerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
      var command = new DeleteCustomerCommand(_context);
      command.Id = id;

      var validator = new DeleteCustomerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPost("connect/token")]
    public IActionResult CreateToken([FromBody] CreateTokenModel login)
    {
      var command = new CreateTokenCommand(_context, _mapper, _configuration);
      command.Model = login;
      var token = command.Handle();

      return Ok(token);
    }

    [HttpGet("refreshToken")]
    public IActionResult RefreshToken([FromQuery] string token)
    {
      var command = new RefreshTokenCommand(_context, _configuration);
      command.RefreshToken = token;
      var resultToken = command.Handle();

      return Ok(resultToken);
    }
  }
}