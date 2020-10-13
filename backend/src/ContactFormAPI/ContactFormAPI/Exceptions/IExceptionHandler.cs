using Microsoft.AspNetCore.Mvc.Filters;
namespace ContactFormAPI.Exceptions
{
    public interface IExceptionHandler
    {
        public void SetNext(IExceptionHandler next);
        public void Handle(ActionExecutedContext context);
    }
}
