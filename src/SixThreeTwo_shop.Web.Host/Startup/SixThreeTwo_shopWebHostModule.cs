using Abp.Modules;
using Abp.Reflection.Extensions;
using SixThreeTwo_shop.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SixThreeTwo_shop.Web.Host.Startup
{
    [DependsOn(
       typeof(SixThreeTwo_shopWebCoreModule))]
    public class SixThreeTwo_shopWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SixThreeTwo_shopWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SixThreeTwo_shopWebHostModule).GetAssembly());
        }
    }
}
