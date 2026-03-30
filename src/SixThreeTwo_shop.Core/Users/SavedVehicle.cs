using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Authorization.Users;

namespace SixThreeTwo_shop.Users;

[Table("SavedVehicles")]
public class SavedVehicle: Entity
{
  public int Year { get; set; }
  
  public string Make { get; set; }
  
  public string Model { get; set; }
  
  public string Engine { get; set; }
  
  public string Label { get; set; }
  
  public long UserId { get; set; }
  
  [ForeignKey("UserId")]
  public User User { get; set; }
}
