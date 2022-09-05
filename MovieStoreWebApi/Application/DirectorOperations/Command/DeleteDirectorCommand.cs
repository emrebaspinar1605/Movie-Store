using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Command
{
  public class DeleteDirectorCommand
  {
    private readonly IMovieStoreDbContext _dbContext;

    public int Id { get; set; }

    public DeleteDirectorCommand(IMovieStoreDbContext context)
    {
      _dbContext = context;

    }
    public void Handle()
    {
      var director = _dbContext.Directors.SingleOrDefault(s => s.Id == Id);
      if (director is null)
        throw new InvalidOperationException("Yönetmen bulunamadı.");

      _dbContext.Directors.Remove(director);
      _dbContext.SaveChanges();
    }
  }
  
}