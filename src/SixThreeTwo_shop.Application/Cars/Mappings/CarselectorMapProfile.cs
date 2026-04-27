using AutoMapper;
using SixThreeTwo_shop.Cars.Dto;

namespace SixThreeTwo_shop.Cars.Mappings;

public class CarselectorMapProfile : Profile
{
  public CarselectorMapProfile()
  {
    CreateMap<CarBrand, CarBrandDto>();
    CreateMap<CarModel, CarModelDto>();
    CreateMap<VehicleVariant, VehicleVariantDto>();
  }
}
