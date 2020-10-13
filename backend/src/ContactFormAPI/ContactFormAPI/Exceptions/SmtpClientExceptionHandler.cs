using ContactFormAPI.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ContactFormAPI.Exceptions
{
    public class SmtpClientExceptionHandler : BaseHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is SmtpClientException smtpClientException)
            {
                context.Result = new ObjectResult(smtpClientException)
                {
                    StatusCode = (int)HttpStatusCode.BadGateway,
                    Value = smtpClientException.Message
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
