using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Quantifeed.Excercise.Business.Orders;
using Quantifeed.Excercise.Business.Orders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Baskets.Dto
{
    [AutoMapTo(typeof(Basket))]
    public class CreateBasketDto : CreationAuditedEntityDto<Guid>, ICustomValidate
    {
        [Required]
        public string ClientId { get; set; }
        public CreateOrderDto[] ChildOrders { get; set; }

        public virtual void AddValidationErrors(CustomValidationContext context)
        {
            if (!ChildOrders?.All(x => CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures).Select(culture => new RegionInfo(culture.Name).ISOCurrencySymbol).Contains(x.Currency)) ?? false)
                context.Results.Add(new ValidationResult("Invalid currency"));
            if ((ChildOrders?.Length ?? 0) == 0)
                context.Results.Add(new ValidationResult("Basket Order must have Child Order(s)"));
            if (ChildOrders?.Sum(x => x.Weight) != 1m)
                context.Results.Add(new ValidationResult("Sum of Child Order weight is not equal to 1"));

            // validate client specific rules
            if ((ClientId.ToUpper() == "A" && (ChildOrders.All(x => x is not
                {
                    Type: OrderType.Market,
                    Currency: "HKD",
                    Destination: "DestinationA",
                    NotionalAmount: >= 100
                })))

                ||

                (ClientId.ToUpper() == "B" && (ChildOrders.Sum(y => y.NotionalAmount) < 10000 || ChildOrders.All(x => x is not
                {
                    Type: OrderType.Limit,
                    Currency: "USD",
                    Destination: "DestinationB",
                    NotionalAmount: >= 1000
                })))
               )
            {
                context.Results.Add(new ValidationResult($"Client {ClientId} setting incorrect"));
            }
        }
    }
}
