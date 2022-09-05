using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Queries
{
    public class GetActorsDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetActorsDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetActorsQueryViewModel Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == Id);
            if (actor is null)
                throw new InvalidOperationException("Oyuncu mevcut değil.");
            
            GetActorsQueryViewModel vm = _mapper.Map<GetActorsQueryViewModel>(actor);

            return vm;
        }
    }
}
