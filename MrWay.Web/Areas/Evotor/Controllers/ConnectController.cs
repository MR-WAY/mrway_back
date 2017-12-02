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

        [HttpGet]
        public IActionResult Connect(ConnectDto dto)
        {
            storeRepostory.Add(new Store
            {
                UserId = dto.UserId,
                Token = Guid.NewGuid()
            });

            return Ok();
        }

        [HttpGet("Stores")]
        public List<Store> GetStores()
        {
            return storeRepostory.GetAll();
        }
    }
}