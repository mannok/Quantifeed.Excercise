using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Quantifeed.Excercise.Business.Baskets;
using Quantifeed.Excercise.Business.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Orders.Dto
{
    [AutoMap(typeof(Basket))]
    public class BasketDto : EntityDto<Guid>
    {
        public string ClientId { get; set; }

        public IList<OrderDto> ChildOrders { get; set; }
    }
}
