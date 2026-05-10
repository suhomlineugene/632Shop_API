using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using JetBrains.Annotations;

namespace SixThreeTwo_shop.Products;

[Table("TransmissionFluids")]
public class TransmissionFluid: Entity
{
  public TransmissionType TransmissionType { get; set; }
  
  [CanBeNull] 
  public string Viscosity { get; set; }
  
  public int ProductId { get; set; }
  
  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
