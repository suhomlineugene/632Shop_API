using AutoMapper;
using SixThreeTwo_shop.Cars;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Mapping;

public class CarsMapProfile : Profile
{
    public CarsMapProfile()
    {
        CreateMap<CarBrand, DropdownDto>();

        CreateMap<CarModel, DropdownDto>();

        CreateMap<VehicleVariant, DropdownDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.EngineLabel));
    }
}

