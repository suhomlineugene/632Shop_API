using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using SixThreeTwo_shop.EntityFrameworkCore.Seed;

namespace SixThreeTwo_shop.EntityFrameworkCore;

[DependsOn(
    typeof(SixThreeTwo_shopCoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class SixThreeTwo_shopEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<SixThreeTwo_shopDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    SixThreeTwo_shopDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    SixThreeTwo_shopDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SixThreeTwo_shopEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
