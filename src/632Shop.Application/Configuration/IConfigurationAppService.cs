using 632Shop.Configuration.Dto;
using System.Threading.Tasks;

namespace 632Shop.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
