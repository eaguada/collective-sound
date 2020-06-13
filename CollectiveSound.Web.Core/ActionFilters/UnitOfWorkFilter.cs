using CollectiveSound.EntityFramework;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CollectiveSound.Web.Core.ActionFilters
{
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWorkActionFilter(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var dataModificationRequestTypes = new[] { "post", "put", "delete" };
            if (!dataModificationRequestTypes.Contains(context.HttpContext.Request.Method, StringComparer.InvariantCultureIgnoreCase) ||
                context.Exception != null ||
                !context.ModelState.IsValid)
            {
                return;
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                dbUpdateConcurrencyException.Entries.Single().Reload();
                _dbContext.SaveChanges();
            }
        }
    }
}
