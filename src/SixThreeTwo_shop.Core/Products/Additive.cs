using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("Additives")]
public class Additive: Entity
{
  public string AdditiveType { get; set; }
  
  public int StockQuantity { get; set; }
  
  public int  ProductId { get; set; }
  
  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
