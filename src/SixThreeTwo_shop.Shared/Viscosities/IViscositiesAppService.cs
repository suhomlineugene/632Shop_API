using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using SixThreeTwo_shop.Shared.Viscosities.Dto;

namespace SixThreeTwo_shop.Shared.Viscosities;

public interface IViscositiesAppService : IApplicationService
{
    Task<List<EngineOilViscosityDto>> GetEngineViscositiesList();

    Task<List<TransmissionOilViscosityDto>> GetTransmissionViscositiesList();

    Task<int> CreateEditEngineViscosity(CreateEditEngineOilViscosityDto dto);

    Task<int> CreateEditTransmissionViscosity(CreateEditTransmissionOilViscosityDto dto);

    Task DeleteEngineViscosity(int id);

    Task DeleteTransmissionViscosity(int id);
    
    Task<EngineOilViscosityDto> GetEngineViscosityById(int id);
    
    Task<TransmissionOilViscosityDto> GetTransmissionViscosityById(int id);
}
