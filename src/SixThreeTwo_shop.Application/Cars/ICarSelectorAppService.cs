using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using SixThreeTwo_shop.Cars.Dto;

namespace SixThreeTwo_shop.Cars;

public interface ICarSelectorAppService : IApplicationService
{
  List<short> GetYearsAsync();

  Task<List<CarBrandDto>> GetBrandsAsync(short year);

  Task<List<CarModelDto>> GetModelsByBrandIdAsync(int brandId, short year);

  Task<List<VehicleVariantDto>> GetVariantsByModelIdAsync(int modelId, short year);
}
