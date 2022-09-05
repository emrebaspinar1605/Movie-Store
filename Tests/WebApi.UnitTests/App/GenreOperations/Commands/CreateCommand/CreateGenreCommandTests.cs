using System;
using System.Linq;
using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace Application.GenreOperations.Commands.CreateCommand
{
  public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    public CreateGenreCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      //Arrange
      var genre = new Genre(){
        Name = "WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn",
      };
      _context.Genres.Add(genre);
      _context.SaveChanges();
      CreateGenreQuery command = new CreateGenreQuery(_context);
      command.Model = new CreateGenreModel(){Name = genre.Name};

      //Act && Assert
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Türü Mevcut");
    }
    [Fact]
    public void WhenInvalidInputsAreGiven_Genre_ShouldBeCreated()
    {
       //Arrange
      CreateGenreQuery command = new CreateGenreQuery(_context);
      CreateGenreModel model = new CreateGenreModel()
      {
        Name = "Aşk"
      };
      command.Model = model;
      //Act 
      FluentActions.Invoking(() => command.Handle()).Invoke();

      //Assert
      var genre = _context.Genres.SingleOrDefault(g => g.Name == model.Name);
      genre.Should().NotBeNull();
      
    }
  }
}