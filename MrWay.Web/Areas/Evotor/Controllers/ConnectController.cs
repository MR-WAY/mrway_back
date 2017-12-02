using Microsoft.AspNetCore.Mvc;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DataTransferObjects.Evotor;
using MrWay.Domain.DomainModels.Retail;
using MrWay.Domain.Interfaces.Repositories;
using MrWay.Services;
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
        private readonly AppDbContext context;
        private readonly IStoreRepository storeRepository;
        private readonly IEvotorApi evotorApi;

        public ConnectController(AppDbContext context,IStoreRepository storeRepository, IEvotorApi evotorApi)
        {
            this.context = context;
            this.storeRepository = storeRepository;
            this.evotorApi = evotorApi;
        }

        [HttpPost]
        public ConnectedDto Connect([FromBody] ConnectDto dto)
        {
            var store = new Store
            {
                UserId = dto.UserId
            };
            storeRepository.Add(store);

            return new ConnectedDto
            {
                UserId = store.UserId,
                Token = store.Id.ToString()
            };
        }

        [HttpGet("Products")]
        public async Task<List<Product>> GetAll([FromHeader(Name = "Authorization")] string authorization)
        {
            var store = storeRepository.Get(Guid.Parse(authorization));
            var products = await evotorApi.GetProducts(store.Token, "20171202-261B-402F-8072-72FF7FEE1CB3");

            products.ForEach(x => x.Store = store);

            context.Products.AddRange(products);

            return products;
        }

        [HttpGet("Stores")]
        public List<Store> GetStores()
        {
            return storeRepository.GetAll();
        }
    }
}