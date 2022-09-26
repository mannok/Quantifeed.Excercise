using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Quantifeed.Excercise.MultiTenancy;

namespace Quantifeed.Excercise.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
