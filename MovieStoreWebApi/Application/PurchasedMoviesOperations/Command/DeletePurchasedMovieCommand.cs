using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.PurchasedMoviesOperations.Command
{
  public class DeletePurchasedMovieCommand
  {
    private readonly IMovieStoreDbContext _dbContext;
    public int Id;
    public DeletePurchasedMovieCommand(IMovieStoreDbContext context)
    {
      _dbContext = context;
    }
    public void Handle()
    {
      var purchasedMovies = _dbContext.PurchasedMovies.SingleOrDefault(s => s.Id == Id);
      if (purchasedMovies is null)
        throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");

      purchasedMovies.movieStatus = false;
      
      _dbContext.PurchasedMovies.Update(purchasedMovies);
      _dbContext.SaveChanges();
    }
  }
}