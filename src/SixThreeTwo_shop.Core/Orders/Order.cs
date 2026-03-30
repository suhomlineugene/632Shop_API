using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Authorization.Users;

namespace SixThreeTwo_shop.Orders;

[Table("Orders")]
public class Order : Entity
{
  public string OrderNumber { get; set; }

  public string Status { get; set; }

  public string ShippingName { get; set; }

  public string ShippingAddressLine1 { get; set; }
  
  public string ShippingCity { get; set; }
  
  public string ShippingPostalCode { get; set; }
  
  public string ShippingCountry { get; set; }
  
  public string ShippingMethod { get; set; }
  
  public decimal Subtotal { get; set; }
  
  public decimal DiscountAmount { get; set; }
  
  public decimal Total { get; set; }
  
  public string Notes { get; set; }
  
  public DateTime PlacedAt { get; set; }
  
  public DateTime UpdatedAt { get; set; }
  
  public long UserId { get; set; }
  
  [ForeignKey("UserId")]
  public User User { get; set; }
  
  public int PromotionId { get; set; }
  
  [ForeignKey("PromotionId")]
  public Promotion Promotion { get; set; }
}
