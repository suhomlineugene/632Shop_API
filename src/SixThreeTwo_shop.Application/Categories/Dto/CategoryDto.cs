using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Categories.Dto;

public class CategoryDto: EntityDto<int?>
{
  public string Name { get; set; }
  
  public bool IsActive { get; set; }
}
