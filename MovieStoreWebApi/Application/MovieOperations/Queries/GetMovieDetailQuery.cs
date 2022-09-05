using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Queries
{
  public class GetMovieDetailQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public int Id;

    public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public MovieQueryViewModel Handle()
    {
      var movies = _context.Movies.Include(i=> i.ActorMovies).ThenInclude(t=> t.Actor).Include(i => i.DirectorMovies).ThenInclude(t=> t.Director).SingleOrDefault(x => x.Id == Id);
      if (movies is null)
      throw new InvalidOperationException("Film bulunamadı.");

      var vm = _mapper.Map<MovieQueryViewModel>(movies);

      return vm;
    }
  }
}