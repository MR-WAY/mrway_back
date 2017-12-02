using Microsoft.EntityFrameworkCore.Storage;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Data.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly IDbContextTransaction transaction;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            this.transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            context.SaveChanges();
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}