using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using 632Shop.EntityFrameworkCore;
using 632Shop.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace 632Shop.Web.Tests;

[DependsOn(
    typeof(632ShopWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class 632ShopWebTestModule : AbpModule
{
    public 632ShopWebTestModule(632ShopEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(632ShopWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(632ShopWebMvcModule).Assembly);
    }
}