using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.PurchasedMoviesOperations.Command.Validators
{
  public class GetPurchasedMoviesDetailQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id;

    public GetPurchasedMoviesDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public PurchasedMoviesViewModel Handle()
    {
      var customer = _dbContext.Customers.Include(i => i.PurchasedMovies).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == Id);
      var vm = _mapper.Map<PurchasedMoviesViewModel>(customer);

      return vm;
    }
  }
}