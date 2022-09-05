using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.PurchasedMoviesOperations.Command
{
  public class UpdatePurchaseMovieCommand
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public PurchasedMoviesModel model;
    public int Id;
    public UpdatePurchaseMovieCommand(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
      Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
      var checkPurchasedMovie  = _dbContext.PurchasedMovies.Single(s => s.CustomerId == model.CustomerId &&s.MovieId == model.MovieId);
      var purchasedMovies = _dbContext.PurchasedMovies.SingleOrDefault(s => s.Id == Id);

      if (customer is null)
        throw new InvalidOperationException("Müşteri bulunamadı!");
      else if (movies is null)
        throw new InvalidOperationException("Film bulunamadı!");
      else if (checkPurchasedMovie is not null)
        throw new InvalidOperationException("Müşteri, daha önce bu filmi satın almış!");
      else if(purchasedMovies is null)
        throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");

      purchasedMovies.CustomerId = model.CustomerId == default ? purchasedMovies.CustomerId : model.CustomerId;
      purchasedMovies.MovieId = model.MovieId == default ? purchasedMovies.MovieId : model.MovieId;

      _dbContext.PurchasedMovies.Update(purchasedMovies);
      _dbContext.SaveChanges();
    }
  }
}