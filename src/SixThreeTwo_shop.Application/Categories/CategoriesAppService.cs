using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using SixThreeTwo_shop.Categories.Dto;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Categories;

public class CategoriesAppService : SixThreeTwo_shopAppServiceBase, ICategoriesAppService
{
  private readonly IRepository<ProductCategory> _productCategoryRepository;
  private readonly IMapper _mapper;

  public CategoriesAppService(IRepository<ProductCategory> productCategoryRepository, IMapper mapper)
  {
    _productCategoryRepository = productCategoryRepository;
    _mapper = mapper;
  }

  public async Task CreateEditCategory(CategoryDto categoryDto)
  {
    if (categoryDto.Id == null)
    {
      var productCategory = _mapper.Map<ProductCategory>(categoryDto);
      productCategory.IsActive = true;
      await _productCategoryRepository.InsertAsync(productCategory);
    }
    else
    {
      var existingCategory = await _productCategoryRepository.GetAsync((int)categoryDto.Id);
      _mapper.Map(categoryDto, existingCategory);
      await _productCategoryRepository.UpdateAsync(existingCategory);
    }
  }

  public async Task<List<CategoryDto>> GetCategoriesList()
  {
    var categories = await _productCategoryRepository.GetAllListAsync();
    
    return _mapper.Map<List<CategoryDto>>(categories);
  }

  public async Task DeleteCategory(int categoryId)
  {
    await _productCategoryRepository.DeleteAsync(categoryId);
  }

  public async Task<CategoryDto> GetCategoryForEdit(int categoryId)
  {
    var category = await _productCategoryRepository.FirstOrDefaultAsync(x=> x.Id == categoryId);
    
    return _mapper.Map<CategoryDto>(category);
  }
}
