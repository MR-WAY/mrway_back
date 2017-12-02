using MrWay.Domain.DomainModels.Retail;
using MrWay.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using MrWay.Data.Infrastructure.Context;

namespace MrWay.Data.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
