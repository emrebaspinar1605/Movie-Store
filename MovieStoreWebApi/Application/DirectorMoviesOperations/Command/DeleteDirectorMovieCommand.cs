using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;


namespace WebApi.Application.DirectorMoviesOperations.Command
{
  public class DeleteDirectorMovieCommand
  {
    private readonly IMovieStoreDbContext _dbContext;
    public int Id;
    public DeleteDirectorMovieCommand(IMovieStoreDbContext context)
    {
     _dbContext = context;
    }
    public void Handle()
    {
      var directorMovies = _dbContext.DirectorMovies.SingleOrDefault(s => s.Id == Id);
      if (directorMovies is null)
        throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");
      
      _dbContext.DirectorMovies.Remove(directorMovies);
      _dbContext.SaveChanges();
    }
  }
}