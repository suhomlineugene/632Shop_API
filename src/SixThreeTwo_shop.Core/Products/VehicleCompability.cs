using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("VehicleCompabilities")]
public class VehicleCompability : Entity
{
  public int YearTo { get; set; }
  
  public int YearFrom { get; set; }
  
  public string Make { get; set; }
  
  public string Model { get; set; }
  
  public string Engine { get; set; }
  
  public int ProductId { get; set; }

  [ForeignKey("ProductId")] 
  public Product Product { get; set; }
}
