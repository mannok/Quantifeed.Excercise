using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Quantifeed.Excercise.Business.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    public class OrderDto : EntityDto<Guid>
    {
        public OrderType Type { get; set; }
        private string currency;
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public decimal NotionalAmount { get; set; }
        public string Destination { get; set; }
        public decimal Weight { get; set; }
    }
}
