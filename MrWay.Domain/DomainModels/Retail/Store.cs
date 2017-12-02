using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels.Retail
{
    public class Store : Entity
    {
        public string UserId { get; set; }
        public Guid Token { get; set; }
    }
}