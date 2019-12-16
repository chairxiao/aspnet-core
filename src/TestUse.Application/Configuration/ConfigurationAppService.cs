using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TestUse.Configuration.Dto;

namespace TestUse.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestUseAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
