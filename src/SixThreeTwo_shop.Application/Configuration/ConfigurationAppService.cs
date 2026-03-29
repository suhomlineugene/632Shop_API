using Abp.Authorization;
using Abp.Runtime.Session;
using SixThreeTwo_shop.Configuration.Dto;
using System.Threading.Tasks;

namespace SixThreeTwo_shop.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : SixThreeTwo_shopAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
