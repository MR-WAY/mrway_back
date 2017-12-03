using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Order
{
    public class Order : Entity
    {
        public int Code { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual List<OrderLine> Lines { get; set; }
    }
}