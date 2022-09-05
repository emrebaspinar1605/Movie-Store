using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.PurchasedMoviesOperations.Command.Validators
{
  public class GetPurchasedMoviesQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public List<PurchasedMoviesViewModel> Handle()
    {
      var list = _dbContext.Customers.Include(i => i.PurchasedMovies).ThenInclude(t => t.Movie).Where(w => w.PurchasedMovies.Any(a => a.movieStatus)).OrderBy(x => x.Id).ToList();
      var vm = _mapper.Map<List<PurchasedMoviesViewModel>>(list);

      return vm;
    }
  }

  public class PurchasedMoviesViewModel
  {
      public string NameSurname { get; set; }
      public IReadOnlyCollection<string> Movies { get; set; }
      public IReadOnlyCollection<string> Price { get; set; }
      public IReadOnlyCollection<string> PurchasedDate { get; set; }
  }
}