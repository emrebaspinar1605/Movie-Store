using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
  public class GetGenresQuery
  {
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<GenresViewModel> Handle()
    {
      var genres = _context.Genres.OrderBy(x => x.Id);
      List<GenresViewModel> list = _mapper.Map<List<GenresViewModel>>(genres);
      return list;
    }

  }
  public class GenresViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}