using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Orders;

[Table("ReturnItems")]
public class ReturnItem : Entity
{
  public int ReturnId { get; set; }

  public int OrderItemId { get; set; }

  public int Quantity { get; set; }

  public string ConditionNotes { get; set; }

  [ForeignKey("OrderItemId")]
  public OrderItem OrderItem { get; set; }

  [ForeignKey("ReturnId")]
  public Return Return { get; set; }
}
