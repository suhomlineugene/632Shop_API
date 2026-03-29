using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SixThreeTwo_shop.Controllers
{
    public abstract class SixThreeTwo_shopControllerBase : AbpController
    {
        protected SixThreeTwo_shopControllerBase()
        {
            LocalizationSourceName = SixThreeTwo_shopConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
