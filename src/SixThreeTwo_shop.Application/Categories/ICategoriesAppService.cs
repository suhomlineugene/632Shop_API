using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using SixThreeTwo_shop.Categories.Dto;

namespace SixThreeTwo_shop.Categories;

public interface ICategoriesAppService : IApplicationService
{
  Task CreateEditCategory(CategoryDto categoryDto);

  Task<List<CategoryDto>> GetCategoriesList();
  
  Task DeleteCategory (int categoryId);
  
  Task<CategoryDto> GetCategoryForEdit(int categoryId);
}
