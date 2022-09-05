using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.ActorMoviesOperation.Queries
{
  public class GetActorMoviesDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetActorMoviesDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public GetActorMovieViewModel Handle()
        {
            var actors = _dbContext.Actors.Include(i=> i.ActorMovies).ThenInclude(t=> t.Movie).SingleOrDefault(x=> x.Id == Id);
            if(actors is null)
                throw new InvalidOperationException("Oyuncu bulunamadı.");

            GetActorMovieViewModel vm = _mapper.Map<GetActorMovieViewModel>(actors);

            return vm;
        }
    }

    public class GetActorMovieViewModel
    {
        public string NameSurName { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
}