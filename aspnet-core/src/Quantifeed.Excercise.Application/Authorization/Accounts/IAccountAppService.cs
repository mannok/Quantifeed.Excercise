using System.Threading.Tasks;
using Abp.Application.Services;
using Quantifeed.Excercise.Authorization.Accounts.Dto;

namespace Quantifeed.Excercise.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
