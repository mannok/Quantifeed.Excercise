using Abp.Application.Services;
using Quantifeed.Excercise.MultiTenancy.Dto;

namespace Quantifeed.Excercise.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

