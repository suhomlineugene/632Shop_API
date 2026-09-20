using AutoMapper;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Viscosities.Dto;

namespace SixThreeTwo_shop.Mapping;

public class ViscositiesMapProfile : Profile
{
    public ViscositiesMapProfile()
    {
        CreateMap<EngineOilViscosity, EngineOilViscosityDto>();
        CreateMap<EngineOilViscosityDto, EngineOilViscosity>();
        CreateMap<EngineOilViscosity, CreateEditEngineOilViscosityDto>();
        CreateMap<CreateEditEngineOilViscosityDto, EngineOilViscosity>();

        CreateMap<TransmissionOilViscosity, TransmissionOilViscosityDto>();
        CreateMap<TransmissionOilViscosityDto, TransmissionOilViscosity>();
        CreateMap<TransmissionOilViscosity, CreateEditTransmissionOilViscosityDto>();
        CreateMap<CreateEditTransmissionOilViscosityDto, TransmissionOilViscosity>();
    }
}
