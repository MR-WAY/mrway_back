using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Retail
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public string uuid { get; set; }

        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}