using Microsoft.AspNetCore.Mvc;
using MrWay.Domain.DataTransferObjects.Evotor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Evotor.Controllers
{
    [Area("Evotor")]
    [Route("api/[area]/[controller]")]
    public class ConnectController
    {
        [HttpGet]
        public ConnectDto Connect(
            [FromHeader(Name = "X-Evotor-Store-Uuid")] string storeId,
            [FromHeader(Name = "X-Evotor-Device-UUID")] string deviceId,
            [FromHeader(Name = "X-Evotor-User-Id")] string userId,
            [FromHeader(Name = "Authorization")] string token
        )
        {
            return new ConnectDto
            {
                StoreId = storeId,
                DeviceId = deviceId,
                UserId = userId,
                Token = token
            };
        }
    }
}