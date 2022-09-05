using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.FavoritesGenreOperations.Queries
{
  public class GetFavoritesGenreQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetFavoritesGenreQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public List<FavoritesGenreQueryViewModel> Handle()
    {
        var list = _dbContext.Customers.Include(i => i.FavoritesGenres).OrderBy(x => x.Id).ToList();
        var vm = _mapper.Map<List<FavoritesGenreQueryViewModel>>(list);

        return vm;
    }
  }

  public class FavoritesGenreQueryViewModel
  {
    public string NameSurname { get; set; }
    public IReadOnlyList<string> Genres { get; set; }
  }
}