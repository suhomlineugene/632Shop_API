using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("MotorsOilToOilApprovals")]
public class MotorOilToOilApproval: Entity
{
  public int MotorOilId { get; set; }
  
  public int OilApprovalId { get; set; }
  
  [ForeignKey("MotorOilId")]
  public MotorOil MotorOil { get; set; }
  
  [ForeignKey("OilApprovalId")]
  public OilApproval OilApproval { get; set; }
}
