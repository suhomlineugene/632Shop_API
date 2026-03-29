using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using 632Shop.Authorization;

namespace 632Shop;

[DependsOn(
    typeof(632ShopCoreModule),
    typeof(AbpAutoMapperModule))]
public class 632ShopApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<632ShopAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(632ShopApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
