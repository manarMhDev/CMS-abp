using System.Threading.Tasks;
using CMS.Manar.Configuration.Dto;

namespace CMS.Manar.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
