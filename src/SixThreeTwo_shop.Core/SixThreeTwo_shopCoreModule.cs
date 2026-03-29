using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using SixThreeTwo_shop.Authorization.Roles;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.Configuration;
using SixThreeTwo_shop.Localization;
using SixThreeTwo_shop.MultiTenancy;
using SixThreeTwo_shop.Timing;

namespace SixThreeTwo_shop;

[DependsOn(typeof(AbpZeroCoreModule))]
public class SixThreeTwo_shopCoreModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Auditing.IsEnabledForAnonymousUsers = true;

        // Declare entity types
        Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
        Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
        Configuration.Modules.Zero().EntityTypes.User = typeof(User);

        SixThreeTwo_shopLocalizationConfigurer.Configure(Configuration.Localization);

        // Enable this line to create a multi-tenant application.
        Configuration.MultiTenancy.IsEnabled = SixThreeTwo_shopConsts.MultiTenancyEnabled;

        // Configure roles
        AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

        Configuration.Settings.Providers.Add<AppSettingProvider>();

        Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));

        Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = SixThreeTwo_shopConsts.DefaultPassPhrase;
        SimpleStringCipher.DefaultPassPhrase = SixThreeTwo_shopConsts.DefaultPassPhrase;
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SixThreeTwo_shopCoreModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
    }
}
