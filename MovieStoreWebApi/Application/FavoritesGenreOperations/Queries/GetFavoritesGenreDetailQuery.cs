using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.FavoritesGenreOperations.Queries
{
  public class GetFavoritesGenreDetailQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id;

    public GetFavoritesGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public FavoritesGenreQueryViewModel Handle()
    {
      var customer = _dbContext.Customers.Include(i => i.FavoritesGenres).SingleOrDefault(s => s.Id == Id);
      FavoritesGenreQueryViewModel vm = _mapper.Map<FavoritesGenreQueryViewModel>(customer);

      return vm;
    }
  }
}