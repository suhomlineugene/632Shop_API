using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Shared.EngineOils.Dto;

public class EngineOilDto: ProductClientDto
{
    public string? Viscosity { get; set; }
}