using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Retail
{
    public class Store : Entity
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}