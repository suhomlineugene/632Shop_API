using AutoMapper;
using SixThreeTwo_shop.Categories.Dto;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Categories.Mappings;

public class ProductCategoryMapProfile : Profile
{
  public ProductCategoryMapProfile()
  {
    CreateMap<ProductCategory, CategoryDto>();
    
    CreateMap<CategoryDto, ProductCategory>();
  }
}
