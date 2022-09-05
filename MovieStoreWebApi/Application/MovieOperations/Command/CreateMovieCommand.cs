using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Command
{
  public class CreateMovieCommand
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateMovieModel Model;

    public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Handle()
    {
      var movie = _context.Movies.SingleOrDefault(x => x.Name.Trim().ToLower() == Model.Name.Trim().ToLower());  
      if (movie is not null)
          throw new InvalidOperationException("Film zaten mevcut!");
          
      movie = _mapper.Map<Movie>(Model);

      _context.Movies.Add(movie);
      _context.SaveChanges();
    }
  }
  public class CreateMovieModel
  { 
    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public int GenreId { get; set; }
    public int Price { get; set; }
    
  }
}