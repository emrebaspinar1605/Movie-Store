using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.ActorMoviesOperation.Queries
{
  public class GetActorMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public List<GetActorMovieViewModel> Handle()
        {
            var actors = _dbContext.Actors.Include(i=> i.ActorMovies).ThenInclude(t=> t.Movie).OrderBy(x=> x.Id).ToList();
            List<GetActorMovieViewModel> vm = _mapper.Map<List<GetActorMovieViewModel>>(actors);

            return vm;
        }
    }
}