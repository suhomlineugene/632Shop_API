using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using 632Shop.EntityFrameworkCore.Seed;

namespace 632Shop.EntityFrameworkCore;

[DependsOn(
    typeof(632ShopCoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class 632ShopEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<632ShopDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    632ShopDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    632ShopDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(632ShopEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
