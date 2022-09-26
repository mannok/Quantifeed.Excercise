using System.Threading.Tasks;
using Abp.Application.Services;
using Quantifeed.Excercise.Sessions.Dto;

namespace Quantifeed.Excercise.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
