using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}