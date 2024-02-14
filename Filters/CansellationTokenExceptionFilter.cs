using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CansellationTokenExample.Filters
{
    public class CansellationTokenExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CansellationTokenExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CansellationTokenExceptionFilter>();
        }

        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is OperationCanceledException or TaskCanceledException)
            {
                _logger.LogInformation("Task kill");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(400);
            }
        }
    }
}
