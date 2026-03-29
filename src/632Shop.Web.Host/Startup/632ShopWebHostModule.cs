using Abp.Modules;
using Abp.Reflection.Extensions;
using 632Shop.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace 632Shop.Web.Host.Startup
{
    [DependsOn(
       typeof(632ShopWebCoreModule))]
    public class 632ShopWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public 632ShopWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(632ShopWebHostModule).GetAssembly());
        }
    }
}
