using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace SixThreeTwo_shop.Products;

[Table("Products")]
public class Product : FullAuditedEntity
{
  public string Name { get; set; }

  public string Description { get; set; }

  public decimal Price { get; set; }

  public bool IsAvailable { get; set; }

  public string Capacity { get; set; }

  public string CountryOfOrigin { get; set; }

  public ProductType ProductType { get; set; }

  // Linked sub-entities (one-to-one per product type)
  public MotorOil? MotorOil { get; set; }
  public Coolant? Coolant { get; set; }
  public TransmissionFluid? TransmissionFluid { get; set; }
  public Additive? Additive { get; set; }
}
