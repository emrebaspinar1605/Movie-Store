using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
  public class PurchasedMovie
  {
    [Key]
    public int Id { get; set; }
    public bool movieStatus { get; set; }
    public DateTime purchasedTime { get; set;}
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
  }
}