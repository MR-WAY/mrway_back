using MrWay.Domain.DomainModels.Retail;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Order
{
    public class OrderLine : Entity
    {
        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}