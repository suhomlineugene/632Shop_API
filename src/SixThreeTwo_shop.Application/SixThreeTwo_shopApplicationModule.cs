using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SixThreeTwo_shop.Authorization;

namespace SixThreeTwo_shop;

[DependsOn(
    typeof(SixThreeTwo_shopCoreModule),
    typeof(AbpAutoMapperModule))]
public class SixThreeTwo_shopApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<SixThreeTwo_shopAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(SixThreeTwo_shopApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
