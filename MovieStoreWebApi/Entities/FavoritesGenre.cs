using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
  public class FavoritesGenre
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FavoritesGenreId { get; set; }
        public Genre Genre { get; set;}
    }
}