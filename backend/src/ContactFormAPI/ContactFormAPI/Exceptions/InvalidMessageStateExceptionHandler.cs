using ContactFormAPI.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ContactFormAPI.Exceptions
{
    public class InvalidMessageStateExceptionHandler : BaseHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is InvalidMessageStateException invalidMessageStateException)
            {
                context.Result = new ObjectResult(invalidMessageStateException)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = invalidMessageStateException.Message
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
