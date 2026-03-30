using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("ProductsToCategories")]
public class ProductToCategory: Entity
{
  public int ProductId { get; set; }

  public int CategoryId { get; set; }

  [ForeignKey("ProductId")]
  public Product Product { get; set; }

  [ForeignKey("CategoryId")]
  public ProductCategory ProductCategory { get; set; }
}
