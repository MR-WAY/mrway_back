using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DataTransferObjects.Order
{
    public class OrderLineDto
    {
        public int Quantity { get; set; }
        public ProductDto Product { get; set; }
    }
}
