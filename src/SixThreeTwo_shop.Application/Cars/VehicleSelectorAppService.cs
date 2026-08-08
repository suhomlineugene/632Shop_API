using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Shared.Cars;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Cars;

public class VehicleSelectorAppService(
  IRepository<CarBrand> carBrandRepository,
  IRepository<CarModel> carModelRepository,
  IRepository<VehicleVariant> vehicleVariantRepository)
  : SixThreeTwo_shopAppServiceBase, IVehicleSelectorAppService
{
  private const short FirstProductionYear = 1889;

  public List<DropdownDto> GetYears()
  {
    var currentYear = DateTime.Now.Year;

    return Enumerable.Range(FirstProductionYear, currentYear - FirstProductionYear + 1)
      .Select(year => new DropdownDto { Id = year, Name = year.ToString() })
      .OrderByDescending(x => x.Id)
      .ToList();
  }

  public async Task<List<DropdownDto>> GetBrands(int year)
  {
    var brands = await carBrandRepository.GetAll()
      .Where(b => b.YearFrom <= year && (b.YearTo == 0 || b.YearTo >= year))
      .OrderBy(b => b.Name)
      .ToListAsync();

    return ObjectMapper.Map<List<DropdownDto>>(brands);
  }

  public async Task<List<DropdownDto>> GetModels(int year, int brandId)
  {
    var models = await carModelRepository.GetAll()
      .Where(m => m.BrandId == brandId && m.YearFrom <= year && (m.YearTo == 0 || m.YearTo >= year))
      .OrderBy(m => m.Name)
      .ToListAsync();

    return ObjectMapper.Map<List<DropdownDto>>(models);
  }

  public async Task<List<DropdownDto>> GetVariants(int year, int modelId)
  {
    var variants = await vehicleVariantRepository.GetAll()
      .Where(v => v.ModelId == modelId && v.YearFrom <= year && (v.YearTo == 0 || v.YearTo >= year))
      .OrderBy(v => v.EngineLabel)
      .ToListAsync();

    return ObjectMapper.Map<List<DropdownDto>>(variants);
  }
}

