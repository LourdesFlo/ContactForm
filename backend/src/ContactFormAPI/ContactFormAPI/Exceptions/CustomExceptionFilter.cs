using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactFormAPI.Exceptions
{
    public class CustomExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public IExceptionHandler _exceptionHandler;

        public CustomExceptionFilter(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _exceptionHandler.Handle(context);
        }
    }
}
