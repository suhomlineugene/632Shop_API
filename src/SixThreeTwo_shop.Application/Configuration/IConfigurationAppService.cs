using SixThreeTwo_shop.Configuration.Dto;
using System.Threading.Tasks;

namespace SixThreeTwo_shop.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
