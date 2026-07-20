using AutoMapper;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Brands.Dto;

namespace SixThreeTwo_shop.Mapping;

public class BrandMapProfile : Profile
{
    public BrandMapProfile()
    {
        CreateMap<Brand, BrandDto>();

        CreateMap<BrandDto, Brand>()
            .ForMember(x => x.Products, opt => opt.Ignore());
    }
}


