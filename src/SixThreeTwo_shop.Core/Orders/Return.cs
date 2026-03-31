using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Orders;

[Table("Returns")]
public class Return: Entity
{
  public int OrderId { get; set; }

  public string Status { get; set; }

  public string Reason { get; set; }

  public string LabelTrackingNumber  { get; set; }

  public string LabelCarrier { get; set; }

  public DateTime RequestedAt { get; set; }

  public DateTime ReceivedAt { get; set; }

  [ForeignKey("OrderId")]
  public Order Order { get; set; }
}
