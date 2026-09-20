using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Shared.Products.Dto;

public class ProductClientDto: FullAuditedEntityDto
{
    public string Name { get; set; }
  
    public string Description { get; set; }
  
    public decimal Price { get; set; }
  
    public bool IsAvailable { get; set; }
    
    public string Capacity { get; set; }
  
    public string CountryOfOrigin { get; set; }
}