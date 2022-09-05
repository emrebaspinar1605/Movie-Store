using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
  public class GetGenreDetailQuery
  {
    public int GenreId { get; set; }
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public GenreViewModel Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
      if(genre is null)
      {
        throw new InvalidOperationException("Film Türü Bulunamadı");
      }
      return _mapper.Map<GenreViewModel>(genre);
    }

  }
  public class GenreViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}