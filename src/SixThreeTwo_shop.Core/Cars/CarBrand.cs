using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Cars;

[Table("CarBrands")]
public class CarBrand : Entity
{
  public string Name { get; set; }

  public string Slug { get; set; }
  
  public short YearFrom { get; set; }
  
  public  short YearTo { get; set; }

  public bool IsActive { get; set; }
}
