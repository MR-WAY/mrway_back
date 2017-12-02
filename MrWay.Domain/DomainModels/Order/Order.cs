using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Order
{
    public class Order : Entity
    {
        public OrderStatus OrderStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public virtual List<OrderLine> Lines { get; set; }
    }
}