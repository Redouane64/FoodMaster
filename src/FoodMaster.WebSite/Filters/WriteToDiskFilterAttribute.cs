using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.WebSite.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodMaster.WebSite.Filters
{
    public class WriteToDiskFilterAttribute : ActionFilterAttribute
    {
        private readonly JsonDataContext dataContext;

        public WriteToDiskFilterAttribute(JsonDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();

            await dataContext.WriteToUnderlyingFileAsync();
        }
    }
}
