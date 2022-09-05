using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorsQueryViewModel> Handle()
        {
            var actors = _context.Actors.OrderBy(x => x.Id).ToList();            
            List<GetActorsQueryViewModel> vm = _mapper.Map<List<GetActorsQueryViewModel>>(actors);

            return vm;
        }

    }

    public class GetActorsQueryViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}