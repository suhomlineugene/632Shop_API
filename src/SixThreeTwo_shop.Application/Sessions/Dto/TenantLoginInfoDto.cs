using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixThreeTwo_shop.MultiTenancy;

namespace SixThreeTwo_shop.Sessions.Dto;

[AutoMapFrom(typeof(Tenant))]
public class TenantLoginInfoDto : EntityDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
