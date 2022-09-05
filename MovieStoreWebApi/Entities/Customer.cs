using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
  public class Customer
  {
    [Key]
    public int  Id { get; set; }
    public string Name { get; set; }
    public string  SurName { get; set; }
     public string Email { get; set; }
    public string Password { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public virtual ICollection<PurchasedMovie> PurchasedMovies { get; set; }
    public virtual ICollection<FavoritesGenre> FavoritesGenres { get; set; }
  }
}