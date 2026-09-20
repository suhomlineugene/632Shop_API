using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("MotorOils")]
public class MotorOil: Entity
{
  public int StockQuantity { get; set; }
  
  public int ProductId { get; set; }
  
  public int ViscosityId { get; set; }
  
  [ForeignKey("ProductId")]
  public Product Product { get; set; }
  
  [ForeignKey("ViscosityId")]
  public EngineOilViscosity OilViscosity { get; set; }
}
