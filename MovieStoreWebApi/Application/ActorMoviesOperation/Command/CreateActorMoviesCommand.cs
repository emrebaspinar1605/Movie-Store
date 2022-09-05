

using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorMoviesOperation.Command
{
  public class CreateActorMoviesCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorMovieModel model;
        public CreateActorMoviesCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(s => s.Id == model.ActorId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(s => s.ActorId == model.ActorId && s.MovieId == model.MovieId);

            if (actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı");
            else if(actorMovies is not null)
                throw new InvalidOperationException("Oyuncu, daha önce bu filmde oynamış.");

            var result = _mapper.Map<ActorMovie>(model);

            _dbContext.ActorMovies.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActorMovieModel
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }

   
}