using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactFormAPI.Exceptions
{
    public abstract class BaseHandler : IExceptionHandler
    {
        protected IExceptionHandler _next;

        public abstract void Handle(ActionExecutedContext context);

        public void SetNext(IExceptionHandler next)
        {
            _next = next;
        }
    }
}
