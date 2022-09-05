using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.FavoritesGenreOperations.Command
{
  public class DeleteFavoriteGenresCommand
  {
    private readonly IMovieStoreDbContext _dbContext;
    public int Id;
    public DeleteFavoriteGenresCommand(IMovieStoreDbContext context)
    {
        _dbContext = context;
    }
    public void Handle()
    {
      var favoriteGenres = _dbContext.FavoritesGenres.SingleOrDefault(s => s.Id == Id);

      if (favoriteGenres is null)
          throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");
      
      _dbContext.FavoritesGenres.Remove(favoriteGenres);
      _dbContext.SaveChanges();
    }
  }
}