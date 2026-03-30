using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("ProductCategory")]
public class ProductCategory: Entity
{
  public string Name { get; set; }

  public bool IsActive { get; set; }
}
