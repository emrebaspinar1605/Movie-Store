using System;
using System.Linq;
using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateCommand
{
  public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    public UpdateGenreCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn()
    {
      UpdateGenreQuery command = new UpdateGenreQuery(_context);
      command.GenreId = 0;
      UpdateGenreModel model = new UpdateGenreModel()
      {
        Name = "WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn"
      };

      //"Aynı İsimli Bir Kitap Türü Mevcuttur"
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle Bir Film Türü Yok");
    }
     [Fact]
    public void WhenValidGenreIdIsGiven_Update_ShouldBeReturn()
    {
      UpdateGenreQuery command = new UpdateGenreQuery(_context);
      command.GenreId = 1;
      UpdateGenreModel model = new UpdateGenreModel()
      {
        Name = "WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn"
      };
      command.Model = model;
      //"Aynı İsimli Bir Kitap Türü Mevcuttur"
      FluentActions.Invoking(() => command.Handle()).Invoke();

      var genre = _context.Genres.SingleOrDefault(g => g.Id == command.GenreId);
      genre.Should().NotBeNull();
    }
  }
}