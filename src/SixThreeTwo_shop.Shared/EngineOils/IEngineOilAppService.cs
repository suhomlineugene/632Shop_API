using SixThreeTwo_shop.Shared.EngineOils.Dto;

namespace SixThreeTwo_shop.Shared.EngineOils;

public interface IEngineOilAppService
{
    Task<List<EngineOilDto>> GetEngineOils(EngineOilFilterDto filterDto);
    
    Task<EngineOilDto> GetEngineOilById(int id);
}