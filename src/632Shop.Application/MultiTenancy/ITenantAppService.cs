using Abp.Application.Services;
using 632Shop.MultiTenancy.Dto;

namespace 632Shop.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

