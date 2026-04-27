using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Cars;

namespace SixThreeTwo_shop.Products;

[Table("ProductCompabilities")]
public class ProductCompability : Entity
{
  public int VariantId { get; set; }

  public int ProductId { get; set; }

  public string OilSpec { get; set; }

  public string FilterRef { get; set; }

  public int OilCapacityMl { get; set; }

  [ForeignKey(nameof(VariantId))] 
  public VehicleVariant Variant { get; set; } = null!;
}
