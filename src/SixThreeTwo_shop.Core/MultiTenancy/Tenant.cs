using Abp.MultiTenancy;
using SixThreeTwo_shop.Authorization.Users;

namespace SixThreeTwo_shop.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
