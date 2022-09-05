using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
  public class DeleteGenreQuery
  {
    public int GenreId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteGenreQuery( IMovieStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);
      if (genre is null)
      {
        throw new InvalidOperationException("Film türü Bulunamadı.");
      }
      _context.Genres.Remove(genre);
      _context.SaveChanges();
    }
  }

}