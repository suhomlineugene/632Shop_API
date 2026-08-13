using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.HomePage;

[Table("MainBanners")]
public class MainBanner: Entity
{
  public string BadgeText { get; set; }

  public bool IsBadgeVisible { get; set; }

  public string Title { get; set; }

  public string Description { get; set; }

  public string ImageUrl { get; set; }

  public bool IsActive { get; set; }
}
