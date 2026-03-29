using Abp.Authorization;
using Abp.Runtime.Session;
using 632Shop.Configuration.Dto;
using System.Threading.Tasks;

namespace 632Shop.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : 632ShopAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
