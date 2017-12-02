using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DataTransferObjects
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
