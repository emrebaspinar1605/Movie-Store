using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
  public interface IMovieStoreDbContext
  {
    DbSet<Movie> Movies { get; set; }
    DbSet<Actor> Actors { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<ActorMovie> ActorMovies { get; set; }
    DbSet<DirectorMovie> DirectorMovies { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<PurchasedMovie> PurchasedMovies { get; set; }
    DbSet<FavoritesGenre> FavoritesGenres { get; set; }
    DbSet<Genre> Genres { get; set; }

    int SaveChanges();
  }
}