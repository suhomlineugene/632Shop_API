using Abp.Application.Services;
using SixThreeTwo_shop.Shared.Brands.Dto;

namespace SixThreeTwo_shop.Shared.Brands;

public interface IBrandsAppService : IApplicationService
{
  Task<List<BrandDto>> GetAllAsync();

  Task<BrandDto> GetByIdAsync(int id);

  Task DeleteBrand(int id);

  Task<int> CreateEditBrand(BrandDto brandDto);
}
