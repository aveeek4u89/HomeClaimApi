using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Models
{
    public class LoggingAspectAttribute: ActionFilterAttribute, IActionFilter
    {
        private ILogWriter logger;
        private Stopwatch stopwatch = new Stopwatch();

        public LoggingAspectAttribute()
        {
            logger = new LogWriter("C:/Logs/CategoryMongoDB/", "log.log");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
            logger.WriteSeperator();
            logger.Write("Request incoming time: " + DateTime.Now);
            logger.Write("Operation name : " + context.HttpContext.Request.Method);
            logger.Write("IP address of the requestor : " + context.HttpContext.Connection.LocalIpAddress + ":" + context.HttpContext.Connection.LocalPort);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            logger.Write("Response time (in Second): " + stopwatch.Elapsed.Seconds);
            stopwatch.Stop();
        }
    }
}
