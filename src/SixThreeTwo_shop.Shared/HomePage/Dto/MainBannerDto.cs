using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Shared.HomePage.Dto;

public class MainBannerDto : EntityDto
{
  public string BadgeText { get; set; }

  public bool IsBadgeVisible { get; set; }

  public string Title { get; set; }

  public string Description { get; set; }

  public string ImageUrl { get; set; }

  public bool IsActive { get; set; }
}
