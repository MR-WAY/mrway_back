using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DomainModels
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}