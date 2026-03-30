using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Orders;

[Table("Promotions")]
public class Promotion: Entity
{
  public string Code { get; set; }
  
  public string DiscountType { get; set; }
  
  public decimal DiscountAmount { get; set; }
  
  public decimal MinimumOrderAmount { get; set; }
  
  public int MaxUses { get; set; }
  
  public int UsedCount { get; set; }
  
  public DateTime ExpiresAt { get; set; }
  
  public bool IsActive { get; set; }
}
