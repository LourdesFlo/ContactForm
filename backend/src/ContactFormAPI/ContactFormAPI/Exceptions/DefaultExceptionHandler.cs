using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace ContactFormAPI.Exceptions
{
    public class DefaultExceptionHandler : BaseHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(exception)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Value = "Internal error"
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
