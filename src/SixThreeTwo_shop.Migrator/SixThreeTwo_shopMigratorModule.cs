using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SixThreeTwo_shop.Configuration;
using SixThreeTwo_shop.EntityFrameworkCore;
using SixThreeTwo_shop.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace SixThreeTwo_shop.Migrator;

[DependsOn(typeof(SixThreeTwo_shopEntityFrameworkModule))]
public class SixThreeTwo_shopMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public SixThreeTwo_shopMigratorModule(SixThreeTwo_shopEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(SixThreeTwo_shopMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            SixThreeTwo_shopConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SixThreeTwo_shopMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
