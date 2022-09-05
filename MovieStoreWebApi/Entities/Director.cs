using System.Collections.Generic;

namespace WebApi.Entities
{
  public class Director
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }
  }
}