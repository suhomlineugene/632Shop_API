using Abp.Application.Services;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Shared.Products;

public interface IProductsAppService : IApplicationService
{
  Task<List<ProductDto>> GetAllProducts();
  
  Task<ProductDto> GetProductById(int id);
  
  Task<int> CreateOrEditProduct(CreateEditProductDto productDto);
  
  Task DeleteProduct(int id);

  Task<int> ImportProductsFromFile(Stream fileStream, string fileName);

  List<DropdownDto> GetProductTypeDropdown();
}
