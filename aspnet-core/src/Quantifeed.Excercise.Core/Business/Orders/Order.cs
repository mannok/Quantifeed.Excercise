using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.Registration;
using Microsoft.EntityFrameworkCore;
using Quantifeed.Excercise.Business.Baskets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Orders
{
    [Index(nameof(Type))]
    [Index(nameof(Currency))]
    [Index(nameof(Symbol))]
    [Index(nameof(NotionalAmount))]
    [Index(nameof(Destination))]
    [Index(nameof(BasketId))]
    [Index(nameof(Weight))]
    public class Order : FullAuditedEntity<Guid>
    {
        public Order()
        {
        }

        [Column("OrderId")]
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public OrderType Type { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public decimal NotionalAmount { get; set; }
        public string Destination { get; set; }
        [ForeignKey(nameof(Basket))]
        public Guid BasketId { get; set; }
        public decimal Weight { get; set; }

        public virtual Basket Basket { get; set; }
    }

    public enum OrderType
    {
        Limit = 10,
        Market = 20
    }
}
