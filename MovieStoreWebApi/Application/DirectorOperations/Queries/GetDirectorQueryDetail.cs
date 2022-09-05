using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries
{
  public class GetDirectorQueryDetail
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int Id;

    public GetDirectorQueryDetail(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public DirectorQueryViewModel Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(s => s.Id == Id);
        var vm = _mapper.Map<DirectorQueryViewModel>(director);

        return vm;
    }
  }
}