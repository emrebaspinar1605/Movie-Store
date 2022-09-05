using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
  public class CreateGenreQuery
  {
    public CreateGenreModel Model { get; set; }
    private readonly IMovieStoreDbContext _context ;
  
    public CreateGenreQuery(IMovieStoreDbContext context )
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
      if (genre is not null)
      {
        throw new InvalidOperationException("Film Türü Mevcut");
      }
      genre = new Genre();
      genre.Name = Model.Name;
      _context.Genres.Add(genre);
      _context.SaveChanges();
      
    }
  }

  public class CreateGenreModel
  {
    public string Name { get; set; }
  }
}