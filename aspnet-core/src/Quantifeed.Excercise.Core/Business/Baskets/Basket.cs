using Abp.Domain.Entities.Auditing;
using Quantifeed.Excercise.Business.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Baskets
{
    public class Basket : FullAuditedAggregateRoot<Guid>
    {
        public Basket()
        {
        }

        [Column("BasketId")]
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public string ClientId { get; set; }

        [InverseProperty(nameof(Order.Basket))]
        public virtual IList<Order> ChildOrders { get; set; }
    }
}
