using System;
using System.Linq;
using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteCommand
{
  public class DeleteGenreCommandTests :IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    public DeleteGenreCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenGenreIdIsGivenWrong_Delete_ShouldBeReturn()
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(_context);
      query.GenreId = 0;

      //Act && Assert
      FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film türü Bulunamadı.");
    }
    [Fact]
    public void WhenGenreIdIsGiven_Delete_ShouldBeRetun()
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(_context);
      query.GenreId = 1;

      //Act 
      FluentActions.Invoking(() => query.Handle()).Invoke();

      //Assert
      var genre = _context.Genres.SingleOrDefault(g => g.Id == query.GenreId);
      genre.Should().BeNull();
    }
  }
}