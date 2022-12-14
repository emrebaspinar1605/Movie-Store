using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Command
{
   public class CreateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model;

        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var result = _mapper.Map<Actor>(Model);
            
            _context.Actors.Add(result);
            _context.SaveChanges();
        }
    }
       public class CreateActorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}