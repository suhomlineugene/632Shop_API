using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using JetBrains.Annotations;

namespace SixThreeTwo_shop.Products;

[Table("TransmissionFluids")]
public class TransmissionFluid: Entity
{
  public TransmissionType TransmissionType { get; set; }
  
  public int? ViscosityId { get; set; }
  
  public int StockQuantity { get; set; }
  
  public int ProductId { get; set; }
  
  [ForeignKey("ProductId")]
  public Product Product { get; set; }
  
  [ForeignKey("ViscosityId")]
  public TransmissionOilViscosity Viscosity { get; set; }
}
