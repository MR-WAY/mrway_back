using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DataTransferObjects.Order
{
    public class CreateOrderDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
