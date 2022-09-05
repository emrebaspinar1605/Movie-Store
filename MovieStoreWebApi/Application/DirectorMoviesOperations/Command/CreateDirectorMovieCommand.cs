using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorMoviesOperations.Command
{
  public class CreateDirectorMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public DirectorMovieModel model;
        public CreateDirectorMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(s => s.Id == model.DirectorId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var directorMovies = _dbContext.DirectorMovies.SingleOrDefault(s => s.MovieId == model.MovieId);

            if (director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if(directorMovies is not null)
                throw new InvalidOperationException("Bu filmin yönetmeni mevcut!");

            var result = _mapper.Map<DirectorMovie>(model);

            _dbContext.DirectorMovies.Add(result);
            _dbContext.SaveChanges();
        }
    }

    public class DirectorMovieModel
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
    }
}