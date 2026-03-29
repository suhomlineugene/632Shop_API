using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SixThreeTwo_shop.EntityFrameworkCore;
using SixThreeTwo_shop.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SixThreeTwo_shop.Web.Tests;

[DependsOn(
    typeof(SixThreeTwo_shopWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class SixThreeTwo_shopWebTestModule : AbpModule
{
    public SixThreeTwo_shopWebTestModule(SixThreeTwo_shopEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SixThreeTwo_shopWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(SixThreeTwo_shopWebMvcModule).Assembly);
    }
}