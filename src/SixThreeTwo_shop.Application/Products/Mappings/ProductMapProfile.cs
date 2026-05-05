using AutoMapper;
using SixThreeTwo_shop.Products.Dto;

namespace SixThreeTwo_shop.Products.Mappings;

public class ProductMapProfile : Profile
{
    public ProductMapProfile()
    {
        CreateMap<Product, ProductDto>();

        CreateMap<CreateOrEditProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
    }
}

