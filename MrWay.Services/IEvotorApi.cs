using MrWay.Domain.DomainModels.Retail;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrWay.Services
{
    public interface IEvotorApi
    {
        [Get("/v1/inventories/stores/{storeId}/products")]
        Task<List<Product>> GetProducts(
            [Header("X-Authorization")] string token,
            [AliasAs("storeId")] string storeId
        );
    }
}