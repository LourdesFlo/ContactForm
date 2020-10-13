using ContactFormAPI.Repositories.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ContactFormAPI.Exceptions
{
    public class MessageNotFoundExceptionHandler : BaseHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is MessageNotFoundException messageNotFoundException)
            {
                context.Result = new ObjectResult(messageNotFoundException)
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Value = messageNotFoundException.Message
                };
                context.ExceptionHandled = true;
            }
            else
            {
                if(this._next != null)
                {
                    this._next.Handle(context);
                }
            }
        }
    }
}
