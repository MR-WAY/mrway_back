using System;
using Microsoft.AspNetCore.Mvc.Filters;
using MrWay.Domain.Interfaces.UnitOfWork;

namespace MrWay.Web.Filters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        private readonly IUnitOfWorkManager unitOfWorkManager;
        private IUnitOfWork unit;

        public UnitOfWorkAttribute(IUnitOfWorkManager unitOfWorkManager)
        {
            this.unitOfWorkManager = unitOfWorkManager;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            unit = unitOfWorkManager.Create();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                try
                {
                    unit.Commit();
                }
                catch (Exception ex)
                {
                    unit.Rollback();
                    throw ex;
                }
            }
            else
            {
                unit.Rollback();
            }
        }
    }
}