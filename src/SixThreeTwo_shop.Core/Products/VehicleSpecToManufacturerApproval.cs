using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Cars;

namespace SixThreeTwo_shop.Products;

[Table("VehicleSpecToManufacturerApprovals")]
public class VehicleSpecToManufacturerApproval: Entity
{
  public int VehicleSpecId { get; set; }
  
  public int ManufacturerApprovalId { get; set; }
  
  [ForeignKey("VehicleSpecId")]
  public VehicleVariant VehicleVariant { get; set; }
  
  [ForeignKey("ManufacturerApprovalId")]
  public ManufacturerApproval ManufacturerApproval { get; set; }
}
