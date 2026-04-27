using Abp.Application.Services.Dto;
using SixThreeTwo_shop.Cars.Enums;

namespace SixThreeTwo_shop.Cars.Dto;

public class VehicleVariantDto : EntityDto
{
  public short YearFrom { get; set; }

  public short YearTo { get; set; }

  public string? EngineCode { get; set; }

  public string EngineLabel { get; set; }

  public FuelType FuelType { get; set; }

  public string? Displacement { get; set; }

  public bool IsActive { get; set; }
}
