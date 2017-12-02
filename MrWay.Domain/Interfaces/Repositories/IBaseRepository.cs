using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(List<TEntity> entities);
        void Remove(TEntity entity);
        TEntity Get(Guid id);
        TEntity Find(Guid id);
        List<TEntity> GetAll();
    }
}