using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Cars.Enums;

namespace SixThreeTwo_shop.Cars;

[Table("VehicleVariants")]
public class VehicleVariant: Entity
{
  public int ModelId { get; set; }
  
  public short YearFrom { get; set; }
  
  public short YearTo { get; set; }
  
  public string? EngineCode { get; set; }
  
  public string EngineLabel { get; set; }
  
  public FuelType FuelType { get; set; }
  
  public string? Displacement { get; set; }
  
  public bool IsActive { get; set; }

  [ForeignKey(nameof(ModelId))]
  public CarModel Model { get; set; }
}
