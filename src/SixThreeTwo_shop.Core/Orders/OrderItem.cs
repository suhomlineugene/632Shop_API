using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Orders;

[Table("OrderItems")]
public class OrderItem: Entity
{
  public int OrderId { get; set; }

  public int ProductId { get; set; }

  public int Quantity { get; set; }

  public decimal LineTotal { get; set; }

  [ForeignKey("OrderId")]
  public Order Order { get; set; }

  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
