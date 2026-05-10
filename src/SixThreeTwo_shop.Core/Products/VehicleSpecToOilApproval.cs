using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Cars;

namespace SixThreeTwo_shop.Products;

[Table("VehicleSpecToOilApprovals")]
public class VehicleSpecToOilApproval: Entity
{
  public int VehicleSpecId { get; set; }
  
  public int OilApprovalId { get; set; }
  
  [ForeignKey("VehicleSpecId")]
  public VehicleVariant VehicleSpec { get; set; }
  
  [ForeignKey("OilApprovalId")]
  public OilApproval OilApproval { get; set; }
}
