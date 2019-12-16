using System.Threading.Tasks;
using TestUse.Configuration.Dto;

namespace TestUse.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
