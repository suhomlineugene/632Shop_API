using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Common.Dto;

namespace SixThreeTwo_shop.Shared.Products.Dto;

public class CreateEditProductDto : FullAuditedEntityDto
{
  public string Name { get; set; }

  public string Description { get; set; }

  public decimal Price { get; set; }

  public bool IsAvailable { get; set; }

  public string Capacity { get; set; }

  public string CountryOfOrigin { get; set; }
  
  public string? Viscosity { get; set; }
  
  public string? CoolantApproval { get; set; }
  
  public string? TransmissionViscosity { get; set; }
  
  public string? AdditiveType { get; set; }

  public ProductType ProductType { get; set; }
  
  public TransmissionType TransmissionType { get; set; }
  
  public ProductFileDto? ProductCoverImage { get; set; }
  
  public ICollection<ProductFileDto>? ProductImages { get; set; }
}
