using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Cars.Dto;

namespace SixThreeTwo_shop.Cars;

[AllowAnonymous]
public class CarSelectorAppService(
  IRepository<CarBrand> carBrandRepository,
  IRepository<CarModel> carModelRepository,
  IRepository<VehicleVariant> vehicleVariantRepository,
  IMapper mapper)
  : SixThreeTwo_shopAppServiceBase, ICarSelectorAppService
{
  public List<short> GetYearsAsync()
  {
    var years = Enumerable.Range(1958, DateTime.Now.Year - 1958 + 1)
      .Select(y => (short)y)
      .OrderByDescending(y => y)
      .ToList();

    return years;
  }

  public async Task<List<CarBrandDto>> GetBrandsAsync(short year)
  {
    var carBrands = await (await carBrandRepository.GetAllAsync()).Where(x => x.YearFrom <= year && x.YearTo >= year)
      .ToListAsync();

    return mapper.Map<List<CarBrandDto>>(carBrands);
  }

  public async Task<List<CarModelDto>> GetModelsByBrandIdAsync(int brandId, short year)
  {
    var carModels = await (await carModelRepository.GetAllAsync())
      .Where(x => x.BrandId == brandId && x.YearFrom <= year && x.YearTo >= year).ToListAsync();

    return mapper.Map<List<CarModelDto>>(carModels);
  }

  public async Task<List<VehicleVariantDto>> GetVariantsByModelIdAsync(int modelId, short year)
  {
    var carVariants =
      await (await vehicleVariantRepository.GetAllAsync())
        .Where(x => x.ModelId == modelId && x.YearFrom <= year && x.YearTo >= year).ToListAsync();

    return mapper.Map<List<VehicleVariantDto>>(carVariants);
  }
}
