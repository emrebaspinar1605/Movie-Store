using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Command
{
  public class DeleteMovieCommand
  {
    private readonly IMovieStoreDbContext _context;
    public int Id;

    public DeleteMovieCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);

      if (movie is null)
        throw new InvalidOperationException("Silinecek kitap bulunamadı.");

      var actorMovies = _context.ActorMovies.Where(x => x.MovieId == Id).ToList();
      foreach (var item in actorMovies)
      {
        _context.ActorMovies.Remove(item);
      }
    
      _context.Movies.Remove(movie);
      _context.SaveChanges();
    }
  }
}