using Microsoft.AspNetCore.Mvc;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DataTransferObjects.Evotor;
using MrWay.Domain.DomainModels.Retail;
using MrWay.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Evotor.Controllers
{
    [Area("Evotor")]
    [Route("api/[area]/[controller]")]
    public class ConnectController : Controller
    {
        private readonly IStoreRepository storeRepostory;

        public ConnectController(IStoreRepository storeRepostory)
        {
            this.storeRepostory = storeRepostory;
        }

        [HttpPost]
        public ConnectedDto Connect([FromBody] ConnectDto dto)
        {
            var store = new Store
            {
                UserId = dto.UserId,
                Token = Guid.NewGuid()
            };
            storeRepostory.Add(store);

            return new ConnectedDto
            {
                UserId = store.UserId,
                Token = store.Token.ToString()
            };
        }

        [HttpGet("Stores")]
        public List<Store> GetStores()
        {
            return storeRepostory.GetAll();
        }
    }
}