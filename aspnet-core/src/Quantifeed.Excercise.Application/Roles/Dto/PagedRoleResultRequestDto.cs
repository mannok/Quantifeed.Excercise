using Abp.Application.Services.Dto;

namespace Quantifeed.Excercise.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

