using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using 632Shop.Configuration;
using 632Shop.EntityFrameworkCore;
using 632Shop.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace 632Shop.Migrator;

[DependsOn(typeof(632ShopEntityFrameworkModule))]
public class 632ShopMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public 632ShopMigratorModule(632ShopEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(632ShopMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            632ShopConsts.ConnectionStringName
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
        IocManager.RegisterAssemblyByConvention(typeof(632ShopMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
