using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Quantifeed.Excercise.Business.Baskets.Dto;
using Quantifeed.Excercise.Business.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Baskets
{
    public interface IBasketAppService : IAsyncCrudAppService<BasketDto, Guid, PagedAndSortedResultRequestDto, CreateBasketDto>, IApplicationService, ISingletonDependency
    {
    }
}
