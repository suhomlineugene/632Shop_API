using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace 632Shop.Controllers
{
    public abstract class 632ShopControllerBase : AbpController
    {
        protected 632ShopControllerBase()
        {
            LocalizationSourceName = 632ShopConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
