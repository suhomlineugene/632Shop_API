using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Cars.Dto;

public class CarModelDto : EntityDto
{
  public string Name { get; set; }
  
  public string Slug { get; set; }
  
  public bool IsActive { get; set; }
}
