using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorMoviesOperations.Queries
{
  public class GetDirectorMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetDirectorMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public GetDirectorMovieViewModel Handle()
        {
            var director = _dbContext.Directors.Include(i=> i.DirectorMovies).ThenInclude(t=> t.Movie).SingleOrDefault(s=> s.Id == Id);
            if(director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");

            GetDirectorMovieViewModel vm = _mapper.Map<GetDirectorMovieViewModel>(director);

            return vm;
        }
    }
}