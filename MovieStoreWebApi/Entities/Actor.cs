using System.Collections.Generic;

namespace WebApi.Entities
{
  public class Actor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public virtual ICollection<ActorMovie> ActorMovies { get; set; }
  }
}