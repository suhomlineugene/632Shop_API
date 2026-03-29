using Abp.Application.Services;
using SixThreeTwo_shop.MultiTenancy.Dto;

namespace SixThreeTwo_shop.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

