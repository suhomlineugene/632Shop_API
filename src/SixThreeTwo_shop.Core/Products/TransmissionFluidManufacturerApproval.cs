using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("TransmissionFluidManufacturerApprovals")]
public class TransmissionFluidManufacturerApproval: Entity
{
  public int TransmissionFluidId { get; set; }
  
  public int ManufacturerApprovalId { get; set; }
  
  [ForeignKey("TransmissionFluidId")]
  public TransmissionFluid TransmissionFluid { get; set; }
  
  [ForeignKey("ManufacturerApprovalId")]
  public ManufacturerApproval ManufacturerApproval { get; set; }
}
