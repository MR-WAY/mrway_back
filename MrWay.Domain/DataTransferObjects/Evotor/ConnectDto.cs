using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.DataTransferObjects.Evotor
{
    public class ConnectDto
    {
        public string StoreId { get; set; }
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}