using System.Linq;
using AutoMapper;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.EngineOils.Dto;

namespace SixThreeTwo_shop.Mapping;

public class EngineOilsMapProfile : Profile
{
    public EngineOilsMapProfile()
    {
        CreateMap<Product, EngineOilDto>(MemberList.None);

        CreateMap<MotorOil, EngineOilDto>()
            .IncludeMembers(x => x.Product)
            .ForMember(x => x.Viscosity, opt => opt.MapFrom(m => m.OilViscosity != null ? m.OilViscosity.Name : null))
            .ForMember(x => x.CoverImageUrl, opt => opt.MapFrom(m =>
                m.Product != null && m.Product.ProductImages != null
                    ? m.Product.ProductImages.Where(i => i.IsCover).Select(i => i.Url).FirstOrDefault()
                    : null));
    }
}
