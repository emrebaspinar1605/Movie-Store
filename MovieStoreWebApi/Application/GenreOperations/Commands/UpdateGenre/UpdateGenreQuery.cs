using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreQuery
  {
    public int GenreId { get; set; }
    public UpdateGenreModel Model{ get; set; }
    private readonly IMovieStoreDbContext _context;
   
    public UpdateGenreQuery(IMovieStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);
      if(genre is null)
        throw new InvalidOperationException("Böyle Bir Film Türü Yok");
      if(_context.Genres.Any(g => g.Name.ToLower() == Model.Name.ToLower() && g.Id != GenreId))
        throw new InvalidOperationException("Aynı İsimli Bir Film Türü Mevcuttur");
      genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
      _context.SaveChanges();
    }
  }
  public class UpdateGenreModel
  {
    public string Name { get; set; }
  }
}