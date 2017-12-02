using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Order
{
    public class EvotorOrderDto
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public List<EvotorOrderLineDto> Lines { get; set; }
    }
}