using Abp.Application.Services;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Shared.Cars;

public interface IVehicleSelectorAppService : IApplicationService
{
  /// <summary>
  /// Returns all years from 1889 (the year the automobile industry started) up to the current year.
  /// Id and Name are both set to the year value.
  /// </summary>
  List<DropdownDto> GetYears();

  /// <summary>
  /// Returns car brands that were in production during the given year.
  /// </summary>
  Task<List<DropdownDto>> GetBrands(int year);

  /// <summary>
  /// Returns car models of the given brand that were in production during the given year.
  /// </summary>
  Task<List<DropdownDto>> GetModels(int year, int brandId);

  /// <summary>
  /// Returns vehicle variants of the given model that were in production during the given year.
  /// </summary>
  Task<List<DropdownDto>> GetVariants(int year, int modelId);
}


