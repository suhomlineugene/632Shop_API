using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("MotorOilManufacturerApprovals")]
public class MotorOilManufacturerApproval: Entity
{
  public int MotorOilId { get; set; }
  
  public int ManufacturerApprovalId { get; set; }
  
  [ForeignKey("MotorOilId")]
  public MotorOil MotorOil { get; set; }
  
  [ForeignKey("ManufacturerApprovalId")]
  public ManufacturerApproval ManufacturerApproval { get; set; }
}
