using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Cars;

[Table("CarModels")]
public class CarModel: Entity
{
  public string Name { get; set; }
  
  public string Slug { get; set; }
  
  public bool IsActive { get; set; }
  
  public short YearFrom { get; set; }
  
  public short YearTo { get; set; }
  
  public int BrandId { get; set; }
  
  [ForeignKey("BrandId")]
  public CarBrand Brand { get; set; }
}
