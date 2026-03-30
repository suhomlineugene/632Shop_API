using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("ProductImages")]
public class ProductImage: Entity
{
  public string S3Key { get; set; }

  public string AltText { get; set; }

  public int ProductId { get; set; }

  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
