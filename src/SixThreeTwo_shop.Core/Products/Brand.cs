using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("Brands")]
public class Brand: Entity
{
  public string Name { get; set; }

  public ICollection<Product> Products { get; set; }
}
