using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries
{
  public class GetDirectorQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public List<DirectorQueryViewModel> Handle()
    {
      var list = _dbContext.Directors.OrderBy(x => x.Id).ToList();
      var vm = _mapper.Map<List<DirectorQueryViewModel>>(list);

      return vm;
    }
  }

  public class DirectorQueryViewModel
  {
    public string NameSurname { get; set; }
    public IReadOnlyList<string> Movies { get; set; }
  }
}