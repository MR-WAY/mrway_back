using MrWay.Domain.DomainModels;
using MrWay.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MrWay.Data.Infrastructure.Context;

namespace MrWay.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(AppDbContext context)
        {
            dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.Id = SeqGuid.New();
            dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public TEntity Get(Guid id)
        {
            return dbSet.Single(x => x.Id == id);
        }

        public TEntity Find(Guid id)
        {
            return dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Add(List<TEntity> entities)
        {
            entities.ForEach(x => Add(x));
        }
    }
}