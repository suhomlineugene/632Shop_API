using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using 632Shop.Authorization.Roles;
using 632Shop.Authorization.Users;
using 632Shop.Configuration;
using 632Shop.Localization;
using 632Shop.MultiTenancy;
using 632Shop.Timing;

namespace 632Shop;

[DependsOn(typeof(AbpZeroCoreModule))]
public class 632ShopCoreModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Auditing.IsEnabledForAnonymousUsers = true;

        // Declare entity types
        Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
        Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
        Configuration.Modules.Zero().EntityTypes.User = typeof(User);

        632ShopLocalizationConfigurer.Configure(Configuration.Localization);

        // Enable this line to create a multi-tenant application.
        Configuration.MultiTenancy.IsEnabled = 632ShopConsts.MultiTenancyEnabled;

        // Configure roles
        AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

        Configuration.Settings.Providers.Add<AppSettingProvider>();

        Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));

        Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = 632ShopConsts.DefaultPassPhrase;
        SimpleStringCipher.DefaultPassPhrase = 632ShopConsts.DefaultPassPhrase;
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(632ShopCoreModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
    }
}
