using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CMS.Manar.Configuration.Dto;

namespace CMS.Manar.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ManarAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
