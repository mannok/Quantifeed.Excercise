using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Runtime.Validation;
using Quantifeed.Excercise.Business.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Orders.Dto
{
    [AutoMapTo(typeof(Order))]
    public class CreateOrderDto : CreationAuditedEntityDto<Guid>
    {
        [Required]
        public OrderType Type { get; set; }
        private string currency;
        [Required]
        public string Currency { get => currency?.ToUpper(); set => currency = value; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public decimal NotionalAmount { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public decimal Weight { get; set; }
    }
}
