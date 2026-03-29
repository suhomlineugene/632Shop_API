using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using 632Shop.MultiTenancy;

namespace 632Shop.Sessions.Dto;

[AutoMapFrom(typeof(Tenant))]
public class TenantLoginInfoDto : EntityDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
