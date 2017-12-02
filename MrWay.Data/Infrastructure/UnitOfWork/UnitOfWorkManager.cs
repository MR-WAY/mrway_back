using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Data.Infrastructure.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly AppDbContext context;

        public UnitOfWorkManager(AppDbContext context)
        {
            this.context = context;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(context);
        }
    }
}