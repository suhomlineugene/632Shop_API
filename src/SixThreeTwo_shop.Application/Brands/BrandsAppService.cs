using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Brands;
using SixThreeTwo_shop.Shared.Brands.Dto;

namespace SixThreeTwo_shop.Brands;

public class BrandsAppService(IRepository<Brand> brandRepository) : ApplicationService, IBrandsAppService
{
  public async Task<List<BrandDto>> GetAllAsync()
  {
    var brands = await brandRepository.GetAllListAsync();
    return ObjectMapper.Map<List<BrandDto>>(brands);
  }

  public async Task<BrandDto> GetByIdAsync(int id)
  {
    var brand = await brandRepository.GetAsync(id);
    return ObjectMapper.Map<BrandDto>(brand);
  }

  public async Task DeleteBrand(int id)
  {
    await brandRepository.DeleteAsync(id);
  }

  public async Task<int> CreateEditBrand(BrandDto brandDto)
  {
    if (brandDto.Id == 0)
    {
      var brand = ObjectMapper.Map<Brand>(brandDto);
      return await brandRepository.InsertAndGetIdAsync(brand);
    }
    else
    {
      var brand = await brandRepository.GetAsync(brandDto.Id);
      ObjectMapper.Map(brandDto, brand);
      await brandRepository.UpdateAsync(brand);
      return brand.Id;
    }
  }
}
