using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Command
{
  public class UpdateDirectorCommand
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public DirectorModel model;
    public int Id;
    public UpdateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      var director = _dbContext.Directors.SingleOrDefault(s => s.Id == Id);
      if (director is null)
        throw new InvalidOperationException("Yönetmen bulunamadı.");            
      
      director.Name = model.Name == default ? director.Name : model.Name;
       director.SurName = model.SurName == default ? director.SurName : model.SurName;
      _dbContext.Directors.Update(director);
      _dbContext.SaveChanges();            
    }
  }
}