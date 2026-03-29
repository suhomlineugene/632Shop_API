using Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace SixThreeTwo_shop.Authorization.Accounts.Dto;

public class IsTenantAvailableInput
{
    [Required]
    [StringLength(AbpTenantBase.MaxTenancyNameLength)]
    public string TenancyName { get; set; }
}
