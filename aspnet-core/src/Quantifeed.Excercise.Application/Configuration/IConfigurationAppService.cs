using System.Threading.Tasks;
using Quantifeed.Excercise.Configuration.Dto;

namespace Quantifeed.Excercise.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
