using MrWay.Domain.DomainModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DataTransferObjects.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CoordinatesDto Store { get; set; }

        public List<OrderLineDto> Lines { get; set; }
    }
}
