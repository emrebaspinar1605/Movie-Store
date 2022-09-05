

using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.ActorMoviesOperation.Command
{
  public class DeleteActorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int Id;
        public DeleteActorMovieCommand(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(s => s.Id == Id);

            if (actorMovies is null)
                throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");
            
            _dbContext.ActorMovies.Remove(actorMovies);
            _dbContext.SaveChanges();
        }
    }

   
}