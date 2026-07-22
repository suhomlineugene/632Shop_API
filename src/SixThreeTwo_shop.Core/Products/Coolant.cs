using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("Coolants")]
public class Coolant: Entity
{
  public string Approval { get; set; }
  
  public int StockQuantity { get; set; }
  
  public int ProductId { get; set; }
  
  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
