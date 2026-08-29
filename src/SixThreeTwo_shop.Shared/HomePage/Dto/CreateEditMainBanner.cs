using Abp.Application.Services.Dto;
using SixThreeTwo_shop.Shared.Common.Dto;

namespace SixThreeTwo_shop.Shared.HomePage.Dto;

public class CreateEditMainBanner: EntityDto
{
  public string BadgeText { get; set; }
  
  public bool IsBadgeVisible { get; set; }
  
  public string Title { get; set; }
  
  public string Description { get; set; }
  
  public ProductFileDto? Image { get; set; }
  
  public bool IsActive { get; set; }
}
