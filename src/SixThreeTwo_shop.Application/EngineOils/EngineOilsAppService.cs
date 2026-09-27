using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SixThreeTwo_shop.Common;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Common;
using SixThreeTwo_shop.Shared.EngineOils;
using SixThreeTwo_shop.Shared.EngineOils.Dto;

namespace SixThreeTwo_shop.EngineOils;

public class EngineOilsAppService(IRepository<MotorOil> motorOilsRepository, IConfiguration configuration)
    : SixThreeTwo_shopAppServiceBase, IEngineOilAppService
{
    private readonly string _imagesBaseUrl = configuration
        .GetSection(AwsS3Settings.SectionName)
        .Get<AwsS3Settings>()?.ImagesBaseUrl ?? string.Empty;

    public async Task<List<EngineOilDto>> GetEngineOils(EngineOilFilterDto filterDto)
    {
        var query = (await motorOilsRepository.GetAllAsync())
            .Include(x => x.Product).ThenInclude(p => p.ProductImages)
            .Include(x => x.OilViscosity)
            .AsQueryable();

        if (filterDto.BrandId.HasValue)
        {
            query = query.Where(x => x.Product.BrandId == filterDto.BrandId.Value);
        }

        if (filterDto.ViscosityId.HasValue)
        {
            query = query.Where(x => x.ViscosityId == filterDto.ViscosityId.Value);
        }

        var motorOils = await query.ToListAsync();

        var result = ObjectMapper.Map<List<EngineOilDto>>(motorOils);
        return result.Select(x => x.ToPublicImageUrl(_imagesBaseUrl)).ToList();
    }

    public async Task<EngineOilDto> GetEngineOilById(int id)
    {
        var motorOil = await (await motorOilsRepository.GetAllAsync())
            .Include(x => x.Product).ThenInclude(p => p.ProductImages)
            .Include(x => x.OilViscosity)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        var result = ObjectMapper.Map<EngineOilDto>(motorOil);
        return result.ToPublicImageUrl(_imagesBaseUrl);
    }
}