using Microsoft.AspNetCore.Mvc;
using MrWay.Domain.DomainModels.Retail;
using MrWay.Domain.Interfaces.Repositories;
using MrWay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Сustomer.Controllers
{
    [Area("Customer")]
    [Route("api/[area]/[controller]")]
    public class ProductsController
    {
        private readonly IStoreRepository storeRepository;
        private readonly IEvotorApi evotorApi;

        public ProductsController(
            IStoreRepository storeRepository,
            IEvotorApi evotorApi
        )
        {
            this.storeRepository = storeRepository;
            this.evotorApi = evotorApi;
        }

        
    }
}